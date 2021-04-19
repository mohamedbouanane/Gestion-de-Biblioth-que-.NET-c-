using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliothèqueUniversitaire.Models
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


        public PersoneEntity(){}

        public PersoneEntity(string nom, string prénom, string adress)
        {
            Nom = nom;
            Prénom = prénom;
            Adress = adress;
        }

        public PersoneEntity(PersoneEntity persone)
        {
            Id = persone.Id;
            Nom = persone.Nom;
            Prénom = persone.Prénom;
            Adress = persone.Adress;
        }

    }
}
