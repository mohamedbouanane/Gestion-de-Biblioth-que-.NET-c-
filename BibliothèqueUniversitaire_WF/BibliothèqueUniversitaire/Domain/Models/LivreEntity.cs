using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliothèqueUniversitaire.Models
{
    [Table("livre", Schema = "dbo")]
    public partial class LivreEntity
    {
        [Key, Column("numéro"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Numéro { get; set; }

        [Column("titre"), Required]
        public string Titre { get; set; }

        [Column("nbr_pages")]
        public uint? NbrPages { get; set; }

        [Column("prix")]
        public double? Prix { get; set; }


        [Column("provenance")]
        public ProvenanceEntity Provenance { get; set; }

        [Column("auteur_fk"), Required]
        public virtual ICollection<AuteurEntity> Auteurs { get; set; }

        [Column("maison_edition_fk"), Required]
        public virtual MaisonEditionEntity MaisonEdition { get; set; }


        public LivreEntity() { }

        public LivreEntity(string titre, uint nbrPages, double prix, ICollection<AuteurEntity> auteurs, 
            MaisonEditionEntity maisonEdition, ProvenanceEntity provenance)
        {
            Titre = titre;
            NbrPages = nbrPages;
            Prix = prix;
            Auteurs = auteurs;
            MaisonEdition = maisonEdition;
            Provenance = provenance;
        }
    }
}
