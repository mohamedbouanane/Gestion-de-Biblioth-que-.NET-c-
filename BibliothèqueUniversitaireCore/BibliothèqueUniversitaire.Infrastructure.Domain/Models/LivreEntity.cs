
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliothèqueUniversitaire.Infra.Domain.Models
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


        [/*Column("provenance_fk")*/ ForeignKey("provenance_fk")]
        public virtual ProvenanceEntity Provenance { get; set; }

        [Column("auteur_fk"), Required]
        public virtual IEnumerable<AuteurEntity> Auteurs { get; set; }

        [/*Column("maison_edition_fk"),*/ ForeignKey("maison_edition_fk")]
        public virtual ProvenanceEntity MaisonEdition { get; set; }


        public LivreEntity() { }

        public LivreEntity(string titre, uint nbrPages, double prix, IEnumerable<AuteurEntity> auteurs, 
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
