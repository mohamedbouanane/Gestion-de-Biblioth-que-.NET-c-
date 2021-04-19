using System.ComponentModel.DataAnnotations.Schema;

namespace BibliothèqueUniversitaire.Models
{
    [Table("auteur", Schema = "dbo")]
    public partial class AuteurEntity : PersoneEntity
    {
        //public ICollection<LivreEntity> Livres { get; set; }

        public AuteurEntity() { }

        public AuteurEntity(PersoneEntity persone) : base(persone) { }

    }
}
