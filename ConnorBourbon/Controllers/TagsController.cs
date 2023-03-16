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
  }
}