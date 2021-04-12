using System.ComponentModel.DataAnnotations.Schema;

namespace BibliothèqueUniversitaire.Models
{
    [Table("adherent", Schema = "dbo")]
    public partial class AdherentEntity : PersoneEntity
    {

        public AdherentEntity() : base() { }

        public AdherentEntity(PersoneEntity persone) : base(persone) { }
    }
}
