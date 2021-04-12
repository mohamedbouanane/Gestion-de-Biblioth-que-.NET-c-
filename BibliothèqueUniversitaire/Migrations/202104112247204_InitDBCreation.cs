namespace BibliothèqueUniversitaire.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDBCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.personne",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        nom = c.String(nullable: false),
                        prenom = c.String(nullable: false),
                        adress = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.emprunt",
                c => new
                    {
                        num_emprunt = c.Long(nullable: false, identity: true),
                        date_emprunt = c.DateTime(nullable: false),
                        date_retour_emprunt = c.DateTime(nullable: false),
                        Adherent_Id = c.Long(),
                        LivreEmprunté_Numéro = c.Long(),
                    })
                .PrimaryKey(t => t.num_emprunt)
                .ForeignKey("dbo.adherent", t => t.Adherent_Id)
                .ForeignKey("dbo.livre", t => t.LivreEmprunté_Numéro)
                .Index(t => t.Adherent_Id)
                .Index(t => t.LivreEmprunté_Numéro);
            
            CreateTable(
                "dbo.livre",
                c => new
                    {
                        id_personne = c.Long(nullable: false, identity: true),
                        titre = c.String(nullable: false),
                        prix = c.Double(nullable: false),
                        MaisonEdition_Id = c.Long(nullable: false),
                        Provenance_Id = c.Long(),
                    })
                .PrimaryKey(t => t.id_personne)
                .ForeignKey("dbo.maisonEdition", t => t.MaisonEdition_Id)
                .ForeignKey("dbo.provenance", t => t.Provenance_Id)
                .Index(t => t.MaisonEdition_Id)
                .Index(t => t.Provenance_Id);
            
            CreateTable(
                "dbo.provenance",
                c => new
                    {
                        id_provenance = c.Long(nullable: false, identity: true),
                        nom = c.String(nullable: false),
                        adress = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id_provenance);
            
            CreateTable(
                "dbo.adherent",
                c => new
                    {
                        id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.personne", t => t.id)
                .Index(t => t.id);
            
            CreateTable(
                "dbo.auteur",
                c => new
                    {
                        id = c.Long(nullable: false),
                        LivreEntity_Numéro = c.Long(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.personne", t => t.id)
                .ForeignKey("dbo.livre", t => t.LivreEntity_Numéro)
                .Index(t => t.id)
                .Index(t => t.LivreEntity_Numéro);
            
            CreateTable(
                "dbo.maisonEdition",
                c => new
                    {
                        id_provenance = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.id_provenance)
                .ForeignKey("dbo.provenance", t => t.id_provenance)
                .Index(t => t.id_provenance);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.maisonEdition", "id_provenance", "dbo.provenance");
            DropForeignKey("dbo.auteur", "LivreEntity_Numéro", "dbo.livre");
            DropForeignKey("dbo.auteur", "id", "dbo.personne");
            DropForeignKey("dbo.adherent", "id", "dbo.personne");
            DropForeignKey("dbo.emprunt", "LivreEmprunté_Numéro", "dbo.livre");
            DropForeignKey("dbo.livre", "Provenance_Id", "dbo.provenance");
            DropForeignKey("dbo.livre", "MaisonEdition_Id", "dbo.maisonEdition");
            DropForeignKey("dbo.emprunt", "Adherent_Id", "dbo.adherent");
            DropIndex("dbo.maisonEdition", new[] { "id_provenance" });
            DropIndex("dbo.auteur", new[] { "LivreEntity_Numéro" });
            DropIndex("dbo.auteur", new[] { "id" });
            DropIndex("dbo.adherent", new[] { "id" });
            DropIndex("dbo.livre", new[] { "Provenance_Id" });
            DropIndex("dbo.livre", new[] { "MaisonEdition_Id" });
            DropIndex("dbo.emprunt", new[] { "LivreEmprunté_Numéro" });
            DropIndex("dbo.emprunt", new[] { "Adherent_Id" });
            DropTable("dbo.maisonEdition");
            DropTable("dbo.auteur");
            DropTable("dbo.adherent");
            DropTable("dbo.provenance");
            DropTable("dbo.livre");
            DropTable("dbo.emprunt");
            DropTable("dbo.personne");
        }
    }
}
