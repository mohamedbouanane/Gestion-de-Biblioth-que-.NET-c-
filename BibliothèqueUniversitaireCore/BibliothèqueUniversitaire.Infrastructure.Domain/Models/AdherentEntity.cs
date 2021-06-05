
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliothèqueUniversitaire.Infra.Domain.Models
{
    [Table("adherent", Schema = "dbo")]
    public partial class AdherentEntity : PersoneEntity
    {
        public virtual IEnumerable<EmpruntEntity> Emprunts { get; set; }

        public AdherentEntity() : base() { }

        public AdherentEntity(PersoneEntity persone) : base(persone) { }

        public AdherentEntity(IEnumerable<EmpruntEntity> emprunts, PersoneEntity persone) : base(persone)
        {
            Emprunts = emprunts;
        }
    }
}
