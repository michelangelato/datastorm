using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using DataStorm.Web.Models;

namespace DataStorm.Web.Migrations
{
    public partial class RimozioneEdificio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Edifici");

            migrationBuilder.AddColumn<string>(
                name: "Comune",
                table: "Appartamenti",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Indirizzo",
                table: "Appartamenti",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "NumeroPersoneResidenti",
                table: "Appartamenti",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<int>(
                name: "NumeroPiano",
                table: "Appartamenti",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoImmobile",
                table: "Appartamenti",
                nullable: false,
                defaultValue: TipologiaImmobile.Appartamento);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comune",
                table: "Appartamenti");

            migrationBuilder.DropColumn(
                name: "Indirizzo",
                table: "Appartamenti");

            migrationBuilder.DropColumn(
                name: "NumeroPersoneResidenti",
                table: "Appartamenti");

            migrationBuilder.DropColumn(
                name: "NumeroPiano",
                table: "Appartamenti");

            migrationBuilder.DropColumn(
                name: "TipoImmobile",
                table: "Appartamenti");

            migrationBuilder.CreateTable(
                name: "Edifici",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    AppartamentoEdifcioId = table.Column<int>(nullable: true),
                    Comune = table.Column<string>(nullable: true),
                    Indirizzo = table.Column<string>(nullable: true),
                    NumeroPersoneResidenti = table.Column<short>(nullable: false),
                    Provincia = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edifici", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edifici_Appartamenti_AppartamentoEdifcioId",
                        column: x => x.AppartamentoEdifcioId,
                        principalTable: "Appartamenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Edifici_AppartamentoEdifcioId",
                table: "Edifici",
                column: "AppartamentoEdifcioId");
        }
    }
}
