using System;
using System.Collections.Generic;

namespace trellomvc.Models;

public partial class Liste
{
    public int Id { get; set; }

    public string Nom { get; set; } = null!;

    public int IdProjet { get; set; }

    public virtual List<Carte> Cartes { get; } = new List<Carte>();

    public virtual Projet IdProjetNavigation { get; set; } = null!;
}
