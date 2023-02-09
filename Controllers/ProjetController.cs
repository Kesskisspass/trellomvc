
using Microsoft.AspNetCore.Mvc;
using trellomvc.Models;
using System;

public class ProjetController : Controller
{
    static public TrelloContext context = new TrelloContext();
    public ProjetController()
    {

    }
    [HttpGet]
    public IActionResult Index()
    {
        return View(context.Projets.ToList());
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }
}