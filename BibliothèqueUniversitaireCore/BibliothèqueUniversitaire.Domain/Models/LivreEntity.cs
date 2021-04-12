using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliothèqueUniversitaire.Infra.Domain.Models
{
    [Table("livre", Schema = "dbo")]
    public partial class LivreEntity
    {
        [Key, Column("id_personne"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Numéro { get; set; }

        [Column("titre"), Required]
        public string Titre { get; set; }

        [Column("nbr_pages")]
        public uint NbrPages { get; set; }

        [Column("prix")]
        public double Prix { get; set; }

        [Column("auteur_fk"), Required]
        public virtual ICollection<AuteurEntity> Auteurs { get; set; }

        [Column("maison_edition_fk"), Required]
        public MaisonEditionEntity MaisonEdition { get; set; }

        [Column("provenance_fk")]
        public virtual ProvenanceEntity Provenance { get; set; }
    
    }
}
