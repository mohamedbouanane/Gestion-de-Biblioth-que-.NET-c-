
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliothèqueUniversitaire.Infra.Domain.Models
{
    [Table("maison_edition", Schema = "dbo")]
    public partial class MaisonEditionEntity : ProvenanceEntity
    {
        [Column("nom_respensable")]
        public string NomRespensable { get; set; }


        public MaisonEditionEntity() : base() {}

        public MaisonEditionEntity(string nomRespensable, ProvenanceEntity provenance) : base(provenance)
        {
            NomRespensable = nomRespensable;
        }

    }
}
