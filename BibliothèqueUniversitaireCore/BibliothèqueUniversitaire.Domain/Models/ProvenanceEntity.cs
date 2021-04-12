using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliothèqueUniversitaire.Infra.Domain.Models
{
    [Table("provenance", Schema = "dbo")]
    public partial class ProvenanceEntity
    {
        [Key, Column("id_provenance"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Column("nom"), Required]
        public string Nom { get; set; }
        [Column("adress"), Required]
        public string Adress { get; set; }
    
    }
}
