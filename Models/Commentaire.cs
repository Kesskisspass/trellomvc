using System;
using System.Collections.Generic;

namespace trellomvc.Models;

public partial class Commentaire
{
    public int Id { get; set; }

    public string Contenu { get; set; } = null!;

    public DateTime DateCreation { get; set; }

    public int IdUtilisateur { get; set; }

    public int IdCarte { get; set; }

    public virtual Carte IdCarteNavigation { get; set; } = null!;

    public virtual Utilisateur IdUtilisateurNavigation { get; set; } = null!;
}
