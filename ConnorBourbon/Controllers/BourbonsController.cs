using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ConnorBourbon.Models;
using Microsoft.AspNetCore.Authorization;

namespace ConnorBourbon.Controllers
{
  [Authorize]
  public class BourbonsController : Controller
  {
    private readonly BourbonContext _db;


    public BourbonsController(BourbonContext db)
    {
      _db = db;
    }

    [AllowAnonymous]
    public ActionResult Index()
    {
      List<Bourbon> model = _db.Bourbons
                                .Include(bourbon => bourbon.Brand)
                                .ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.BrandId = new SelectList(_db.Brands, "BrandId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Bourbon bourbon)
    {
      if (bourbon.BrandId == 0)
      {
        return RedirectToAction("Create");
      }
      _db.Bourbons.Add(bourbon);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Bourbon thisBourbon = _db.Bourbons
                                .Include(bourbon => bourbon.Brand)
                                .Include(bourbon => bourbon.JoinEntities)
                                .ThenInclude(join => join.Tag)
                                .FirstOrDefault(bourbon => bourbon.BourbonId == id);
      return View(thisBourbon);
    }

    public ActionResult Edit(int id)
    {
      Bourbon thisBourbon = _db.Bourbons.FirstOrDefault(bourbon => bourbon.BourbonId == id);
      ViewBag.BrandId = new SelectList(_db.Brands, "BrandId", "Name");
      return View(thisBourbon);
    }

    [HttpPost]
    public ActionResult Edit(Bourbon bourbon)
    {
      _db.Bourbons.Update(bourbon);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Bourbon thisBourbon = _db.Bourbons.FirstOrDefault(bourbon => bourbon.BourbonId == id);
      ViewBag.field = "Name";
      ViewBag.name = thisBourbon.Name;
      return View(thisBourbon);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Bourbon thisBourbon = _db.Bourbons.FirstOrDefault(bourbon => bourbon.BourbonId == id);
      _db.Bourbons.Remove(thisBourbon);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddTag(int id)
    {
      Bourbon thisBourbon = _db.Bourbons.FirstOrDefault(bourbons => bourbons.BourbonId == id);
      ViewBag.TagId = new SelectList(_db.Tags, "TagId", "Title");
      return View(thisBourbon);
    }

    [HttpPost]
    public ActionResult AddTag(Bourbon bourbon, int tagId)
    {
      #nullable enable
      BourbonTag? joinEntity = _db.BourbonTag.FirstOrDefault(join => (join.TagId == tagId && join.BourbonId == bourbon.BourbonId));
      #nullable disable
      if (joinEntity == null && tagId != 0)
      {
        _db.BourbonTag.Add(new BourbonTag() { TagId = tagId, BourbonId = bourbon.BourbonId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = bourbon.BourbonId });
    }  

    [HttpPost]
    public ActionResult DeleteJoin(int joinId)
    {
      BourbonTag joinEntry = _db.BourbonTag.FirstOrDefault(entry => entry.BourbonTagId == joinId);
      _db.BourbonTag.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}