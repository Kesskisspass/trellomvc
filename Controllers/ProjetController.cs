
using Microsoft.AspNetCore.Mvc;
using trellomvc.Models;
using System;
using Microsoft.EntityFrameworkCore;

public class ProjetController : Controller
{
    static public TrelloContext context = new TrelloContext();
    public ProjetController()
    {

    }
    [HttpGet]
    public IActionResult Index()
    {
        return View(context.Projets.Include(p => p.Listes).ToList());
        // return View(context.Projets.Include(p => p.Listes.Select(l => l.Cartes)).ToList());
    }

    [HttpGet]
    public IActionResult Detail(int id)
    {
        return View(context.Projets.Include(p => p.Listes).ThenInclude(l => l.Cartes).FirstOrDefault(p => p.Id == id));
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Add(Projet projet)
    {
        projet.DateCreation = DateTime.Now;
        context.Projets.Add(projet);
        context.UtilisateurProjets.Add(new UtilisateurProjet() { Projet = projet, Utilisateur = context.Utilisateurs.Find(UtilisateurController.userAuthenticated.Id) });
        context.SaveChanges();
        return RedirectToAction("Index");
    }


}