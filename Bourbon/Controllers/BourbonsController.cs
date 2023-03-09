using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using ConnorBourbon.Models;

namespace ConnorBourbon.Controllers
{
  public class BourbonsController : Controller
  {
    private readonly BourbonContext _db;


    public BourbonsController(BourbonContext db)
    {
      _db = db;
    }

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
                                .FirstOrDefault(bourbon => bourbon.BourbonId == id);
      return View(thisBourbon);
    }

    public ActionResult Edit(int id)
    {
      Bourbon thisBourbon = _db.Bourbons.FirstOrDefault(bourbon => bourbon.BourbonId == id);
      ViewBag.BrandId = new SelectList(_db.Brands, "BrandId", "Name");
      ViewBag.JuiceId = new SelectList(_db.JuiceTypes, "JuiceId", "Name");
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
  }
}