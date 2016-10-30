using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataStorm.Web.Migrations
{
    public partial class ComuniItaliani : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Regioni",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Nome = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regioni", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Province",
                columns: table => new
                {
                    Sigla = table.Column<string>(type: "char", maxLength: 2, nullable: false),
                    Denominazione = table.Column<string>(maxLength: 40, nullable: false),
                    RegioneID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Province", x => x.Sigla);
                    table.ForeignKey(
                        name: "FK_Province_Regioni_RegioneID",
                        column: x => x.RegioneID,
                        principalTable: "Regioni",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comuni",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Denominazione = table.Column<string>(maxLength: 40, nullable: false),
                    SiglaProvincia = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comuni", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comuni_Province_SiglaProvincia",
                        column: x => x.SiglaProvincia,
                        principalTable: "Province",
                        principalColumn: "Sigla",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comuni_SiglaProvincia",
                table: "Comuni",
                column: "SiglaProvincia");

            migrationBuilder.CreateIndex(
                name: "IX_Province_RegioneID",
                table: "Province",
                column: "RegioneID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comuni");

            migrationBuilder.DropTable(
                name: "Province");

            migrationBuilder.DropTable(
                name: "Regioni");
        }
    }
}
