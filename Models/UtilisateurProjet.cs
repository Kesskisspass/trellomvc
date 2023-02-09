namespace trellomvc.Models;
public class UtilisateurProjet
{
    public int UtilisateurID { get; set; }
    public int ProjetID { get; set; }
    public Utilisateur Utilisateur;
    public Projet Projet;

    public UtilisateurProjet()
    {

    }
}