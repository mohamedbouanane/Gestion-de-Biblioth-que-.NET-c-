using BibliothèqueUniversitaire.Models;
using System.Data.Entity;
using System.Windows.Forms;

namespace BibliothèqueUniversitaire.Ifrostructure.Context
{
    public class ModelContext : DbContext
    {
        public DbSet<AdherentEntity> Adherents { get; set; }
        public DbSet<AuteurEntity> Auteurs { get; set; }
        public DbSet<EmpruntEntity> Emprunts { get; set; }
        public DbSet<LivreEntity> Livres { get; set; }
        public DbSet<MaisonEditionEntity> MaisonEditions { get; set; }
        public DbSet<PersoneEntity> Persones { get; set; }
        public DbSet<ProvenanceEntity> Provenance { get; set; }


        public ModelContext() : base("name=db_src") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //MessageBox.Show("Model Creating ...");
        }  

    }
}
