

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliothèqueUniversitaire.Infra.Domain.Models
{
    [Table("auteur", Schema = "dbo")]
    public partial class AuteurEntity : PersoneEntity
    {
        //public ICollection<LivreEntity> Livres { get; set; }
    }
}
