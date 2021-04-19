using System.ComponentModel.DataAnnotations.Schema;

namespace BibliothèqueUniversitaire.Models
{
    [Table("maison_edition", Schema = "dbo")]
    public partial class MaisonEditionEntity : ProvenanceEntity
    {
        public MaisonEditionEntity() : base(){}

        public MaisonEditionEntity(ProvenanceEntity provenance) : base(provenance){ }
    }
}
