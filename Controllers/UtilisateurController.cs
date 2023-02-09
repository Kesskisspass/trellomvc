
using Microsoft.AspNetCore.Mvc;
using trellomvc.Models;
using System;

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
            return RedirectToAction("Index", "Liste");
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
}
