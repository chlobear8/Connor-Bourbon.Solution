using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

using ConnorBourbon.Models;

namespace ConnorBourbon.Controllers
{
    public class JuiceTypesController : Controller
    {
        private readonly BourbonContext _db;

        public JuiceTypesController(BourbonContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Juice> model = _db.JuiceTypes.ToList();
            return View(model);
        }
            public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Juice juice)
    {
      _db.JuiceTypes.Add(juice);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
     {
      Juice thisJuice = _db.JuiceTypes
                                .FirstOrDefault(juice => juice.JuiceId == id);
      return View(thisJuice);
     }

     public ActionResult Edit(int id)
     {
      Juice thisJuice = _db.JuiceTypes.FirstOrDefault(juice => juice.JuiceId == id);
      return View(thisJuice);
     }

     [HttpPost]
     public ActionResult Edit(Juice juice)
     {
      _db.JuiceTypes.Update(juice);
      _db.SaveChanges();
      return RedirectToAction("Index");
     }

     public ActionResult Delete(int id)
     {
      Juice thisJuice = _db.JuiceTypes.FirstOrDefault(juice => juice.JuiceId == id);
      return View(thisJuice);
     }
     [HttpPost, ActionName("Delete")]
     public ActionResult DeleteConfirmed(int id)
     {
      Juice thisJuice = _db.JuiceTypes.FirstOrDefault(juice => juice.JuiceId == id);
      _db.JuiceTypes.Remove(thisJuice);
      _db.SaveChanges();
      return RedirectToAction("Index");
     }
  }
}
