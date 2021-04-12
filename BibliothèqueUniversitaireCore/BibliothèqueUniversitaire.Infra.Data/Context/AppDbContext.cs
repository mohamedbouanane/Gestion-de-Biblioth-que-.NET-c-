using Microsoft.EntityFrameworkCore;
using BibliothèqueUniversitaire.Infra.Domain.Models;
using System.Configuration;
using System;

namespace BibliothèqueUniversitaire.Infra.Data.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<AdherentEntity> Adherents { get; set; }
        public DbSet<AuteurEntity> Auteurs { get; set; }
        public DbSet<EmpruntEntity> Emprunts { get; set; }
        public DbSet<LivreEntity> Livres { get; set; }
        public DbSet<MaisonEditionEntity> MaisonEditions { get; set; }
        public DbSet<PersoneEntity> Persones { get; set; }
        public DbSet<ProvenanceEntity> Provenances { get; set; }


        //public AppDbContext() : base("name=MySrcDb") { }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //MessageBox.Show("Database generated...");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ToString();
            //"Data Source=DESKTOP-5SSJU0Q;Initial Catalog=BibliothèqueUniversitaire;Integrated Security=True" name = "MySrcDb" providerName = "System.Data.SqlClient"
            string connectionString = "Data Source = DESKTOP-5SSJU0Q; Initial Catalog = BibliothèqueUniversitaire; Integrated Security = True";
                
            optionsBuilder.UseSqlServer(connectionString);
            //base.OnConfiguring(optionsBuilder);
        }

    }
}
