using System;
using System.Collections.Generic;

namespace trellomvc.Models;

public partial class Utilisateur
{
    public int Id { get; set; }

    public string Nom { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string MotDePasse { get; set; } = null!;

    public DateTime DateInscription { get; set; }

    public virtual List<Commentaire> Commentaires { get; } = new List<Commentaire>();

    public virtual List<UtilisateurProjet> Projets { get; } = new List<UtilisateurProjet>();

    public Utilisateur()
    {

    }
    public Utilisateur(string Nom, string Email, string MotDePasse)
    {
        this.Nom = Nom;
        this.Email = Email;
        this.MotDePasse = MotDePasse;
        this.DateInscription = DateTime.Now;
    }
}
