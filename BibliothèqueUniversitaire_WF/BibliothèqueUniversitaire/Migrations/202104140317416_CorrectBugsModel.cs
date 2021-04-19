namespace BibliothèqueUniversitaire.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectBugsModel : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.livre", name: "id_personne", newName: "numéro");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.livre", name: "numéro", newName: "id_personne");
        }
    }
}
