
using Microsoft.AspNetCore.Mvc;
using trellomvc.Models;
using System;
using Microsoft.EntityFrameworkCore;

public class UtilisateurController : Controller
{
    static public TrelloContext context = new TrelloContext();
    static public Utilisateur userAuthenticated = null;
    public UtilisateurController()
    {

    }
    [HttpGet]
    public IActionResult Index()
    {
        return View(context.Utilisateurs.ToList());
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Add(Utilisateur nouvelUtilisateur)
    {
        context.Utilisateurs.Add(nouvelUtilisateur);
        context.SaveChanges();
        return RedirectToAction("Index", "Utilisateur");
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string nom, string password)
    {
        Utilisateur userFound = context.Utilisateurs.Where(u => u.Nom == nom && u.MotDePasse == password).FirstOrDefault();
        if (userFound != null)
        {
            userAuthenticated = userFound;
            return RedirectToAction("Mesprojets", "Utilisateur", new { id = userFound.Id });
        }
        else
        {
            System.Console.WriteLine("Utilisateur non trouvé");
            return RedirectToAction("Login", "Utilisateur");
        }
    }
    public IActionResult Logout()
    {
        userAuthenticated = null;
        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public IActionResult Mesprojets(int Id)
    {
        var query = from p in context.Projets
                    join up in context.UtilisateurProjets on p.Id equals up.ProjetID
                    where up.UtilisateurID == Id
                    select p;
        var mesProjets = query.ToList();

        return View(mesProjets);
    }
}
