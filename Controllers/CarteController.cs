using Microsoft.AspNetCore.Mvc;
using trellomvc.Models;
using trellomvc.Controllers;
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

    [HttpPost]
    public IActionResult Add(Carte carte, int Id)

    {
        Console.WriteLine("id = " + Id);
        context.Cartes.Add(carte);
        context.SaveChanges();
        return RedirectToAction("Mesprojets", "Utilisateur", new { id = UtilisateurController.userAuthenticated.Id });
    }
}