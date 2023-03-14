using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

using ConnorBourbon.Models;

namespace ConnorBourbon.Controllers
{
  public class DistilleriesController : Controller
  {
    private readonly BourbonContext _db;

    public DistilleriesController(BourbonContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Distillery> model = _db.Distilleries.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Distillery distillery)
    {
      _db.Distilleries.Add(distillery);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Distillery thisDistillery = _db.Distilleries
                                      .Include(distillery => distillery.Brands)
                                      .FirstOrDefault(distillery => distillery.DistilleryId == id);
      return View(thisDistillery);
    }

    public ActionResult Edit(int id)
    {
      Distillery thisDistillery = _db.Distilleries.FirstOrDefault(distillery => distillery.DistilleryId == id);
      return View(thisDistillery);
    }

    [HttpPost]
    public ActionResult Edit(Distillery distillery)
    {
      _db.Distilleries.Update(distillery);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Distillery thisDistillery = _db.Distilleries.FirstOrDefault(distillery => distillery.DistilleryId == id);
      ViewBag.field = "Name";
      ViewBag.name = thisDistillery.Name;
      return View(thisDistillery);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Distillery thisDistillery = _db.Distilleries.FirstOrDefault(distillery => distillery.DistilleryId == id);
      _db.Distilleries.Remove(thisDistillery);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}