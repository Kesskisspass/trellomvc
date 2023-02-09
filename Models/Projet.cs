using System;
using System.Collections.Generic;

namespace trellomvc.Models;

public partial class Projet
{
    public int Id { get; set; }

    public string Nom { get; set; } = null!;

    public string? Contenu { get; set; }

    public DateTime DateCreation { get; set; }

    public virtual List<Liste> Listes { get; } = new List<Liste>();

    public virtual List<UtilisateurProjet> Utilisateurs { get; } = new List<UtilisateurProjet>();

    public Projet() { }

    public Projet(string nom)
    {
        this.Nom = nom;
        this.DateCreation = DateTime.Now;
    }
}
