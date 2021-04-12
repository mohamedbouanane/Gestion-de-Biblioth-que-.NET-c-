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

        [Column("livre_emprunté")]
        public LivreEntity LivreEmprunté { get; set; }

        [Column("Adherent")]
        public AdherentEntity Adherent { get; set; }
    }
}
