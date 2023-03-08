using Microsoft.AspNetCore.Mvc;

namespace ConnorBourbon.Controllers;

public class HomeController : Controller
{
  public ActionResult Index()
  {
    return View();
  }
}