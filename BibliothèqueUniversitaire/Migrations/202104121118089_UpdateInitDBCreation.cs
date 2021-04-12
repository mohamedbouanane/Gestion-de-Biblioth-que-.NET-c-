namespace BibliothèqueUniversitaire.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateInitDBCreation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.livre", "prix", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.livre", "prix", c => c.Double(nullable: false));
        }
    }
}
