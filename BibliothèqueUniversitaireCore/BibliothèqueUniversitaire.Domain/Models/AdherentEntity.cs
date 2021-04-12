using System.ComponentModel.DataAnnotations.Schema;

namespace BibliothèqueUniversitaire.Infra.Domain.Models
{
    [Table("adherent", Schema = "dbo")]
    public partial class AdherentEntity : PersoneEntity
    {
    }
}
