using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliothèqueUniversitaire.Infra.Domain.Models
{
    [Table("personne", Schema = "dbo")]
    public partial class PersoneEntity
    {
        [Key, Column("id"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Column("nom"), Required]
        public string Nom { get; set; }
        [Column("prenom"), Required]
        public string Prénom { get; set; }
        [Column("adress")]
        public string Adress { get; set; }

    }
}
