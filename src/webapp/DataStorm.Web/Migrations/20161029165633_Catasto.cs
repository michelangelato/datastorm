using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using DataStorm.Web.Models;

namespace DataStorm.Web.Migrations
{
    public partial class Catasto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MetriQuadri",
                table: "Immobili");

            migrationBuilder.DropColumn(
                name: "NumeroPersoneResidenti",
                table: "Immobili");

            migrationBuilder.DropColumn(
                name: "NumeroPiano",
                table: "Immobili");

            migrationBuilder.CreateTable(
                name: "Catasto",
                columns: table => new
                {
                    IdCatasto = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    AnnoDiCostruzione = table.Column<int>(nullable: false),
                    AreaInMq = table.Column<int>(nullable: false),
                    CateneCordoli = table.Column<int>(nullable: false),
                    Comune = table.Column<string>(nullable: true),
                    Costruzione = table.Column<int>(nullable: false),
                    DissestiTerreno = table.Column<int>(nullable: false),
                    Indirizzo = table.Column<string>(nullable: true),
                    NumeroDiPiani = table.Column<int>(nullable: false),
                    PercentualeUtilizzo = table.Column<int>(nullable: false),
                    Posizione = table.Column<int>(nullable: false),
                    Proprieta = table.Column<int>(nullable: false),
                    PuntoMappaId = table.Column<int>(nullable: true),
                    Terreno = table.Column<int>(nullable: false),
                    Uso = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catasto", x => x.IdCatasto);
                    table.ForeignKey(
                        name: "FK_Catasto_PuntiMappa_PuntoMappaId",
                        column: x => x.PuntoMappaId,
                        principalTable: "PuntiMappa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.AddColumn<int>(
                name: "AnnoDiCostruzione",
                table: "Immobili",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AreaInMq",
                table: "Immobili",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CateneCordoli",
                table: "Immobili",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Costruzione",
                table: "Immobili",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DissestiTerreno",
                table: "Immobili",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumeroDiPiani",
                table: "Immobili",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PercentualeUtilizzo",
                table: "Immobili",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Posizione",
                table: "Immobili",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Proprieta",
                table: "Immobili",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Terreno",
                table: "Immobili",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Uso",
                table: "Immobili",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Catasto_PuntoMappaId",
                table: "Catasto",
                column: "PuntoMappaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnnoDiCostruzione",
                table: "Immobili");

            migrationBuilder.DropColumn(
                name: "AreaInMq",
                table: "Immobili");

            migrationBuilder.DropColumn(
                name: "CateneCordoli",
                table: "Immobili");

            migrationBuilder.DropColumn(
                name: "Costruzione",
                table: "Immobili");

            migrationBuilder.DropColumn(
                name: "DissestiTerreno",
                table: "Immobili");

            migrationBuilder.DropColumn(
                name: "NumeroDiPiani",
                table: "Immobili");

            migrationBuilder.DropColumn(
                name: "PercentualeUtilizzo",
                table: "Immobili");

            migrationBuilder.DropColumn(
                name: "Posizione",
                table: "Immobili");

            migrationBuilder.DropColumn(
                name: "Proprieta",
                table: "Immobili");

            migrationBuilder.DropColumn(
                name: "Terreno",
                table: "Immobili");

            migrationBuilder.DropColumn(
                name: "Uso",
                table: "Immobili");

            migrationBuilder.DropTable(
                name: "Catasto");

            migrationBuilder.AddColumn<decimal>(
                name: "MetriQuadri",
                table: "Immobili",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<short>(
                name: "NumeroPersoneResidenti",
                table: "Immobili",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<int>(
                name: "NumeroPiano",
                table: "Immobili",
                nullable: true);
        }
    }
}
