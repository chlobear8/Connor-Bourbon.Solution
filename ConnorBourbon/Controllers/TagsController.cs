using Microsoft.AspNetCore.Mvc;
using ConnorBourbon.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ConnorBourbon.Controllers
{
  public class TagsController : Controller
  {
    private readonly BourbonContext _db;

    public TagsController(BourbonContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Tags.ToList());
    }

    public ActionResult Details(int id)
    {
      Tag thisTag = _db.Tags
          .Include(tag => tag.JoinEntities)
          .ThenInclude(join => join.Bourbon)
          .FirstOrDefault(tag => tag.TagId == id);
      return View(thisTag);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Tag tag)
    {
      _db.Tags.Add(tag);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddBourbon(int id)
    {
      Tag thisTag = _db.Tags.FirstOrDefault(tags => tags.TagId == id);
      ViewBag.BourbonId = new SelectList(_db.Bourbons, "BourbonId", "Name");
      return View(thisTag);
    }

    [HttpPost]
    public ActionResult AddBourbon(Tag tag, int bourbonId)
    {
      #nullable enable
      BourbonTag? joinEntity = _db.BourbonTags.FirstOrDefault(join => (join.BourbonId == bourbonId && join.TagId == tag.TagId));
      #nullable disable
      if (joinEntity == null && bourbonId != 0)
      {
        _db.BourbonTags.Add(new BourbonTag() { BourbonId = bourbonId, TagId = tag.TagId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = tag.TagId });
    }
  }
}