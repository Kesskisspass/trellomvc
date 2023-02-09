using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using trellomvc.Models;

namespace trellomvc.Controllers;

public class HomeController : Controller
{

    public HomeController()
    {
        TrelloContext context = new();
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

}
