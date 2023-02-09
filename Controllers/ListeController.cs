using Microsoft.AspNetCore.Mvc;
using trellomvc.Models;
using System;
using Microsoft.EntityFrameworkCore;

public class ListeController : Controller
{
    static public TrelloContext context = new TrelloContext();
    public ListeController()
    {
    }
    [HttpGet]
    public IActionResult Index()
    {
        return View(context.Listes.Include(l => l.Cartes).ToList());
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Detail(int id)
    {
        Liste listeFound = context.Listes.Find(id);
        if (listeFound != null)
        {
            return View(listeFound);
        }
        else
        {
            System.Console.WriteLine("Liste non trouvée");
            return NotFound();
        }

    }
}