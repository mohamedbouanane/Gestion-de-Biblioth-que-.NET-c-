using System.ComponentModel.DataAnnotations.Schema;

namespace BibliothèqueUniversitaire.Models
{
    [Table("maisonEdition", Schema = "dbo")]
    public partial class MaisonEditionEntity : ProvenanceEntity
    {
        public MaisonEditionEntity() : base(){}

        public MaisonEditionEntity(ProvenanceEntity provenance) : base(provenance){ }
    }
}
