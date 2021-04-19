using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliothèqueUniversitaire.Models
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


        public ProvenanceEntity() { }

        public ProvenanceEntity(ProvenanceEntity provenance)
        {
            Id = provenance.Id;
            Nom = provenance.Nom;
            Adress = provenance.Adress;
        }

        public ProvenanceEntity(string nom, string adress)
        {
            Nom = nom;
            Adress = adress;
        }

        public ProvenanceEntity(long id, string nom, string adress)
        {
            Id = id;
            Nom = nom;
            Adress = adress;
        }

    }
}
