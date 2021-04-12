using System.ComponentModel.DataAnnotations.Schema;

namespace BibliothèqueUniversitaire.Infra.Domain.Models
{
    [Table("maisonEdition", Schema = "dbo")]
    public partial class MaisonEditionEntity : ProvenanceEntity
    {

    }
}
