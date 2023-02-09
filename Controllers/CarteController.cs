using Microsoft.AspNetCore.Mvc;
using trellomvc.Models;
using System;

public class CarteController : Controller
{
    static public TrelloContext context = new TrelloContext();
    public CarteController()
    {
    }
    [HttpGet]
    public IActionResult Index()
    {
        return View(context.Cartes.ToList());
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }
}