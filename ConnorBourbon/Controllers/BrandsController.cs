using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

using ConnorBourbon.Models;

namespace ConnorBourbon.Controllers
{
  public class BrandsController : Controller
  {
    private readonly BourbonContext _db;

    public BrandsController(BourbonContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Brand> model = _db.Brands.ToList();
      return View(model);
    }

    public ActionResult Create(int id)
    {
      Brand thisBrand = _db.Brands.FirstOrDefault(brand => brand.BrandId == id);
      ViewBag.DistilleryId = new SelectList(_db.Distilleries, "DistilleryId", "Name");
      return View(thisBrand);
    }

    [HttpPost]
    public ActionResult Create(Brand brand)
    {
      _db.Brands.Add(brand);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Brand thisBrand = _db.Brands
                            .Include(brand => brand.Bourbons)
                            .ThenInclude(bourbon => bourbon.JoinEntities)
                            .ThenInclude(join => join.Tag)
                            .FirstOrDefault(brand => brand.BrandId == id);
      return View(thisBrand);
    }

    public ActionResult Edit(int id)
    {
      Brand thisBrand = _db.Brands.FirstOrDefault(brand => brand.BrandId == id);
      return View(thisBrand);
    }

    [HttpPost]
    public ActionResult Edit(Brand brand)
    {
      _db.Brands.Update(brand);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Brand thisBrand = _db.Brands.FirstOrDefault(brand => brand.BrandId == id);
      ViewBag.field = "Name";
      ViewBag.name = thisBrand.Name;
      return View(thisBrand);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Brand thisBrand = _db.Brands.FirstOrDefault(brand => brand.BrandId == id);
      _db.Brands.Remove(thisBrand);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}