using Microsoft.AspNetCore.Mvc;
using ConnorBourbon.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace ConnorBourbon.Controllers;

public class HomeController : Controller
{
  private readonly ConnorBourbon _db;
  private readonly UserManager<ApplicationUser> _userManager;

  public HomeController(UserManager<ApplicationUser> userManager, ToDoListContext db)
  {
    _userManager = userManager;
    _db = db;
  }

  [HttpGet("/")]
  public async Task<ActionResult> Index()
  {
    Brands[] bran = _db.Brands.ToArray();
    Dictionary<string,object[]> model = new Dictionary<string, object[]>();
    model.Add("brands", bran);
    string userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
    if (currentUser != null)
    {
      Bourbon[] bourbons = _db.Bourbons
                        .Where(entry => entry.User.Id == currentUser.Id)
                        .ToArray();
      model.Add("bourbons", bourbons);
    }
    return View(model);
  }
}

