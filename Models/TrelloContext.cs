using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace trellomvc.Models;

public partial class TrelloContext : DbContext
{
    public TrelloContext()
    {
        // Database.EnsureDeleted();
        Database.EnsureCreated();
        // Utilisateur u1 = new Utilisateur("Christopher", "chris@mail.com", "0000");
        // Utilisateurs.Add(u1);
        // SaveChanges();

        // Projet p1 = new Projet("Nouveau Trello");
        // Projets.Add(p1);
        // SaveChanges();



    }


    public virtual DbSet<Carte> Cartes { get; set; }

    public virtual DbSet<Commentaire> Commentaires { get; set; }

    public virtual DbSet<Etiquette> Etiquettes { get; set; }

    public virtual DbSet<Liste> Listes { get; set; }

    public virtual DbSet<Projet> Projets { get; set; }

    public virtual DbSet<Utilisateur> Utilisateurs { get; set; }
    public virtual DbSet<UtilisateurProjet> UtilisateurProjets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL("Server=localhost;Port=3306;Database=trello2;User=admin;Password=0000;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carte>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("carte");

            entity.HasIndex(e => e.IdListe, "id_liste");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Contenu)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text")
                .HasColumnName("contenu");
            entity.Property(e => e.DateCreation)
                .HasColumnType("date")
                .HasColumnName("date_creation");
            entity.Property(e => e.IdListe)
                .HasColumnType("int(11)")
                .HasColumnName("id_liste");
            entity.Property(e => e.Titre)
                .HasMaxLength(255)
                .HasColumnName("titre");

            entity.HasOne(d => d.IdListeNavigation).WithMany(p => p.Cartes)
                .HasForeignKey(d => d.IdListe)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("carte_ibfk_1");
        });

        modelBuilder.Entity<Commentaire>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("commentaire");

            entity.HasIndex(e => e.IdCarte, "id_carte");

            entity.HasIndex(e => e.IdUtilisateur, "id_utilisateur");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Contenu)
                .HasColumnType("text")
                .HasColumnName("contenu");
            entity.Property(e => e.DateCreation)
                .HasColumnType("date")
                .HasColumnName("date_creation");
            entity.Property(e => e.IdCarte)
                .HasColumnType("int(11)")
                .HasColumnName("id_carte");
            entity.Property(e => e.IdUtilisateur)
                .HasColumnType("int(11)")
                .HasColumnName("id_utilisateur");

            entity.HasOne(d => d.IdCarteNavigation).WithMany(p => p.Commentaires)
                .HasForeignKey(d => d.IdCarte)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("commentaire_ibfk_2");

            entity.HasOne(d => d.IdUtilisateurNavigation).WithMany(p => p.Commentaires)
                .HasForeignKey(d => d.IdUtilisateur)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("commentaire_ibfk_1");
        });

        modelBuilder.Entity<Etiquette>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("etiquette");

            entity.HasIndex(e => e.IdCarte, "id_carte");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Couleur)
                .HasMaxLength(255)
                .HasColumnName("couleur");
            entity.Property(e => e.IdCarte)
                .HasColumnType("int(11)")
                .HasColumnName("id_carte");
            entity.Property(e => e.Nom)
                .HasMaxLength(255)
                .HasColumnName("nom");

            entity.HasOne(d => d.IdCarteNavigation).WithMany(p => p.Etiquettes)
                .HasForeignKey(d => d.IdCarte)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("etiquette_ibfk_1");
        });

        modelBuilder.Entity<Liste>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("liste");

            entity.HasIndex(e => e.IdProjet, "id_projet");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.IdProjet)
                .HasColumnType("int(11)")
                .HasColumnName("id_projet");
            entity.Property(e => e.Nom)
                .HasMaxLength(255)
                .HasColumnName("nom");

            entity.HasOne(d => d.IdProjetNavigation).WithMany(p => p.Listes)
                .HasForeignKey(d => d.IdProjet)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("liste_ibfk_1");
        });

        modelBuilder.Entity<Projet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("projet");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Contenu)
                .HasDefaultValueSql("'NULL'")
                .HasColumnType("text")
                .HasColumnName("contenu");
            entity.Property(e => e.DateCreation)
                .HasColumnType("date")
                .HasColumnName("date_creation");
            entity.Property(e => e.Nom)
                .HasMaxLength(255)
                .HasColumnName("nom");
        });

        modelBuilder.Entity<Utilisateur>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("utilisateur");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.DateInscription)
                .HasColumnType("date")
                .HasColumnName("date_inscription");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.MotDePasse)
                .HasMaxLength(255)
                .HasColumnName("mot_de_passe");
            entity.Property(e => e.Nom)
                .HasMaxLength(255)
                .HasColumnName("nom");


        });
        modelBuilder.Entity<UtilisateurProjet>(entity =>
        {
            entity.HasKey(e => new { e.ProjetID, e.UtilisateurID }).HasName("PRIMARY");
            entity.ToTable("utilisateurprojet");

            entity.HasOne(e => e.Projet).WithMany(e => e.Utilisateurs);
            entity.HasOne(e => e.Utilisateur).WithMany(e => e.Projets);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
