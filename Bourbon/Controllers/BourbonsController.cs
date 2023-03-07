using Microsoft.AspNetCore.Mvc;
using Bourbon.Models;
using System.Collections.Generic;
using System.Linq;

namespace Bourbon.AddControllers
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
      List<Bourbon> model = _db.Items.ToList();
      return View(model);
    }
  }
}