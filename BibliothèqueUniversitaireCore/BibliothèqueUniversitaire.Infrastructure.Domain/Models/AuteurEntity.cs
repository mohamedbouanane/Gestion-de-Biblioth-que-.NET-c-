
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliothèqueUniversitaire.Infra.Domain.Models
{
    [Table("auteur", Schema = "dbo")]
    public partial class AuteurEntity : PersoneEntity
    {
        public virtual IEnumerable<LivreEntity> Livres { get; set; }

        public AuteurEntity() { }

        public AuteurEntity(PersoneEntity persone) : base(persone) { }

        public AuteurEntity(IEnumerable<LivreEntity> livres, PersoneEntity persone) : base(persone)
        {
            Livres = livres;
        }
    }
}
