using Microsoft.EntityFrameworkCore;
using BibliothèqueUniversitaire.Infra.Domain.Models;
using System.Configuration;
using System;
using System.Windows;

// Config Connection string :
// https://docs.microsoft.com/en-us/ef/core/dbcontext-configuration/
// https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-strings

namespace BibliothèqueUniversitaire.Infra.Data.Context
{
    public class ModelContext : DbContext
    {

        #region DbSet

        public DbSet<AdherentEntity> Adherents { get; set; }
        public DbSet<AuteurEntity> Auteurs { get; set; }
        public DbSet<EmpruntEntity> Emprunts { get; set; }
        public DbSet<LivreEntity> Livres { get; set; }
        public DbSet<MaisonEditionEntity> MaisonEditions { get; set; }
        public DbSet<PersoneEntity> Persones { get; set; }
        public DbSet<ProvenanceEntity> Provenances { get; set; }

        #endregion DbSet


        public ModelContext() { }

        public ModelContext(DbContextOptions<ModelContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //MessageBox.Show("Model generated...");
        }

        // To correctlater Couldent fund the solution to get connection string from app.config ...
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Data Source = DESKTOP-5SSJU0Q; Initial Catalog = BibliothèqueUniversitaire; Integrated Security = True";
            
            // This should be work
            //string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;
            //string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB; Initial Catalog = BibliothèqueUniversitaire; Integrated Security = True");

            optionsBuilder.UseSqlServer(connectionString,
                providerOptions => { providerOptions.EnableRetryOnFailure(); });
            base.OnConfiguring(optionsBuilder);
        }

    }
}
