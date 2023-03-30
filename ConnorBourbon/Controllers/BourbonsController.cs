using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ConnorBourbon.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace ConnorBourbon.Controllers
{
  [Authorize]
  public class BourbonsController : Controller
  {
    private readonly BourbonContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public BourbonsController(UserManager<ApplicationUser> _userManager, BourbonContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    [AllowAnonymous]
    public async <ActionResult> Index()
    {
      string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
      List<Bourbon> userBourbons = _db.Bourbons
                                .Where(entry => entry.User.Id == currentUser.Id)
                                .Include(bourbon => bourbon.Brand)
                                .ToList();
      return View(userBourbons);
    }

    public ActionResult Create()
    {
      ViewBag.BrandId = new SelectList(_db.Brands, "BrandId", "Name");
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(Bourbon bourbon, int BrandId)
    {
      if (!ModelState.IsValid)
      {
        ViewBag.BrandId = new SelectList(_db.Brands, "BrandId", "Name");
        return View(bourbon);
      }
      else
      {
        string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
        bourbon.User = currentUser;
        _db.Bourbons.Add(bourbon);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
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