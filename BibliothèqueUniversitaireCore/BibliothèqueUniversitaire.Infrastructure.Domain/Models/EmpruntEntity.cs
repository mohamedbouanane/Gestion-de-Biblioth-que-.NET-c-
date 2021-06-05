
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliothèqueUniversitaire.Infra.Domain.Models
{
    [Table("emprunt", Schema = "dbo")]
    public partial class EmpruntEntity
    {
        [Key, Column("num_emprunt"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long NumEmrunt { get; set; }

        [Column("date_emprunt")]
        public DateTime DateEmprunt { get; set; }

        [Column("date_retour_emprunt")]
        public DateTime DateRetourEmprunt { get; set; }

        [Column("livre_emprunté_fk")]
        public virtual LivreEntity LivreEmprunté { get; set; }

        [Column("adherent_fk")]
        public virtual AdherentEntity Adherent { get; set; }


        public EmpruntEntity(){}

        public EmpruntEntity(DateTime dateEmprunt, DateTime dateRetourEmprunt, LivreEntity livreEmprunté, AdherentEntity adherent)
        {
            DateEmprunt = dateEmprunt;
            DateRetourEmprunt = dateRetourEmprunt;
            LivreEmprunté = livreEmprunté;
            Adherent = adherent;
        }

        public EmpruntEntity(long numEmrunt, DateTime dateEmprunt, DateTime dateRetourEmprunt, LivreEntity livreEmprunté, AdherentEntity adherent)
        {
            NumEmrunt = numEmrunt;
            DateEmprunt = dateEmprunt;
            DateRetourEmprunt = dateRetourEmprunt;
            LivreEmprunté = livreEmprunté;
            Adherent = adherent;
        }
    }
}
