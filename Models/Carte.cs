using System;
using System.Collections.Generic;

namespace trellomvc.Models;

public partial class Carte
{
    public int Id { get; set; }

    public string Titre { get; set; } = null!;

    public string? Contenu { get; set; }

    public DateTime DateCreation { get; set; }

    public int IdListe { get; set; }

    public virtual List<Commentaire> Commentaires { get; } = new List<Commentaire>();

    public virtual List<Etiquette> Etiquettes { get; } = new List<Etiquette>();

    public virtual Liste IdListeNavigation { get; set; } = null!;
    public Carte()
    {
    }
    public Carte(string titre, int idListe)
    {
        Titre = titre;
        IdListe = idListe;
        DateCreation = DateTime.Now;
    }
}
