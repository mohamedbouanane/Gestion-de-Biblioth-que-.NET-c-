using BibliothèqueUniversitaire.Models;
using System.Data.Entity;
using System.Windows.Forms;

namespace BibliothèqueUniversitaire.Context
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


        public AppDbContext() : base("name=MySrcDb") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            MessageBox.Show("Database generated...");
        }

    }
}
