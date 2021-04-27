using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionRestau.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produits",
                columns: table => new
                {
                    IDProduit = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameProduit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionProduit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrixProduit = table.Column<float>(type: "real", nullable: false),
                    CategorieProduit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatutProduit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CentreDeRevenuProduit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NbPersonnesProduit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produits", x => x.IDProduit);
                });

            migrationBuilder.CreateTable(
                name: "Serveurs",
                columns: table => new
                {
                    IDServeur = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameServeur = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneServeur = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serveurs", x => x.IDServeur);
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    IDTable = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroTable = table.Column<int>(type: "int", nullable: false),
                    NbPlacesTable = table.Column<int>(type: "int", nullable: false),
                    serveurIDServeur = table.Column<int>(type: "int", nullable: true),
                    IDServeur = table.Column<int>(type: "int", nullable: false),
                    OccupationTable = table.Column<bool>(type: "bit", nullable: false),
                    EmplacementTable = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.IDTable);
                    table.ForeignKey(
                        name: "FK_Tables_Serveurs_serveurIDServeur",
                        column: x => x.serveurIDServeur,
                        principalTable: "Serveurs",
                        principalColumn: "IDServeur",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Consommations",
                columns: table => new
                {
                    IDConsommation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tableconsoIDTable = table.Column<int>(type: "int", nullable: true),
                    IDTable = table.Column<int>(type: "int", nullable: false),
                    DateConsommation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuantiteConsommation = table.Column<int>(type: "int", nullable: false),
                    Paye = table.Column<bool>(type: "bit", nullable: false),
                    IDProduit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consommations", x => x.IDConsommation);
                    table.ForeignKey(
                        name: "FK_Consommations_Tables_tableconsoIDTable",
                        column: x => x.tableconsoIDTable,
                        principalTable: "Tables",
                        principalColumn: "IDTable",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConsommationProduit",
                columns: table => new
                {
                    ConsommationsIDConsommation = table.Column<int>(type: "int", nullable: false),
                    ProduitsIDProduit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsommationProduit", x => new { x.ConsommationsIDConsommation, x.ProduitsIDProduit });
                    table.ForeignKey(
                        name: "FK_ConsommationProduit_Consommations_ConsommationsIDConsommation",
                        column: x => x.ConsommationsIDConsommation,
                        principalTable: "Consommations",
                        principalColumn: "IDConsommation",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsommationProduit_Produits_ProduitsIDProduit",
                        column: x => x.ProduitsIDProduit,
                        principalTable: "Produits",
                        principalColumn: "IDProduit",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsommationProduit_ProduitsIDProduit",
                table: "ConsommationProduit",
                column: "ProduitsIDProduit");

            migrationBuilder.CreateIndex(
                name: "IX_Consommations_tableconsoIDTable",
                table: "Consommations",
                column: "tableconsoIDTable");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_serveurIDServeur",
                table: "Tables",
                column: "serveurIDServeur");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsommationProduit");

            migrationBuilder.DropTable(
                name: "Consommations");

            migrationBuilder.DropTable(
                name: "Produits");

            migrationBuilder.DropTable(
                name: "Tables");

            migrationBuilder.DropTable(
                name: "Serveurs");
        }
    }
}
