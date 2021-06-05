using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BibliothèqueUniversitaire.WpfCore.Migrations
{
    public partial class initDBCretion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "personne",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personne", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "provenance",
                schema: "dbo",
                columns: table => new
                {
                    id_provenance = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_provenance", x => x.id_provenance);
                });

            migrationBuilder.CreateTable(
                name: "adherent",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adherent", x => x.id);
                    table.ForeignKey(
                        name: "FK_adherent_personne_id",
                        column: x => x.id,
                        principalSchema: "dbo",
                        principalTable: "personne",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "auteur",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_auteur", x => x.id);
                    table.ForeignKey(
                        name: "FK_auteur_personne_id",
                        column: x => x.id,
                        principalSchema: "dbo",
                        principalTable: "personne",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "livre",
                schema: "dbo",
                columns: table => new
                {
                    numéro = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nbr_pages = table.Column<long>(type: "bigint", nullable: true),
                    prix = table.Column<double>(type: "float", nullable: true),
                    provenance_fk = table.Column<long>(type: "bigint", nullable: true),
                    maison_edition_fk = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_livre", x => x.numéro);
                    table.ForeignKey(
                        name: "FK_livre_provenance_maison_edition_fk",
                        column: x => x.maison_edition_fk,
                        principalSchema: "dbo",
                        principalTable: "provenance",
                        principalColumn: "id_provenance",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_livre_provenance_provenance_fk",
                        column: x => x.provenance_fk,
                        principalSchema: "dbo",
                        principalTable: "provenance",
                        principalColumn: "id_provenance",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "maison_edition",
                schema: "dbo",
                columns: table => new
                {
                    id_provenance = table.Column<long>(type: "bigint", nullable: false),
                    nom_respensable = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_maison_edition", x => x.id_provenance);
                    table.ForeignKey(
                        name: "FK_maison_edition_provenance_id_provenance",
                        column: x => x.id_provenance,
                        principalSchema: "dbo",
                        principalTable: "provenance",
                        principalColumn: "id_provenance",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AuteurEntityLivreEntity",
                schema: "dbo",
                columns: table => new
                {
                    AuteursId = table.Column<long>(type: "bigint", nullable: false),
                    LivresNuméro = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuteurEntityLivreEntity", x => new { x.AuteursId, x.LivresNuméro });
                    table.ForeignKey(
                        name: "FK_AuteurEntityLivreEntity_auteur_AuteursId",
                        column: x => x.AuteursId,
                        principalSchema: "dbo",
                        principalTable: "auteur",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuteurEntityLivreEntity_livre_LivresNuméro",
                        column: x => x.LivresNuméro,
                        principalSchema: "dbo",
                        principalTable: "livre",
                        principalColumn: "numéro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "emprunt",
                schema: "dbo",
                columns: table => new
                {
                    num_emprunt = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date_emprunt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    date_retour_emprunt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LivreEmpruntéNuméro = table.Column<long>(type: "bigint", nullable: true),
                    AdherentId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emprunt", x => x.num_emprunt);
                    table.ForeignKey(
                        name: "FK_emprunt_adherent_AdherentId",
                        column: x => x.AdherentId,
                        principalSchema: "dbo",
                        principalTable: "adherent",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_emprunt_livre_LivreEmpruntéNuméro",
                        column: x => x.LivreEmpruntéNuméro,
                        principalSchema: "dbo",
                        principalTable: "livre",
                        principalColumn: "numéro",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuteurEntityLivreEntity_LivresNuméro",
                schema: "dbo",
                table: "AuteurEntityLivreEntity",
                column: "LivresNuméro");

            migrationBuilder.CreateIndex(
                name: "IX_emprunt_AdherentId",
                schema: "dbo",
                table: "emprunt",
                column: "AdherentId");

            migrationBuilder.CreateIndex(
                name: "IX_emprunt_LivreEmpruntéNuméro",
                schema: "dbo",
                table: "emprunt",
                column: "LivreEmpruntéNuméro");

            migrationBuilder.CreateIndex(
                name: "IX_livre_maison_edition_fk",
                schema: "dbo",
                table: "livre",
                column: "maison_edition_fk");

            migrationBuilder.CreateIndex(
                name: "IX_livre_provenance_fk",
                schema: "dbo",
                table: "livre",
                column: "provenance_fk");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuteurEntityLivreEntity",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "emprunt",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "maison_edition",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "auteur",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "adherent",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "livre",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "personne",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "provenance",
                schema: "dbo");
        }
    }
}
