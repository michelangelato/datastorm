using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataStorm.Web.Migrations
{
    public partial class AddColonneValutazione : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AnnoDiCostruzione",
                table: "Immobili",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CateneCordoli",
                table: "Immobili",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Costruzione",
                table: "Immobili",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumeroDiPiani",
                table: "Immobili",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PercentualeUtilizzo",
                table: "Immobili",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Posizione",
                table: "Immobili",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Proprieta",
                table: "Immobili",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Uso",
                table: "Immobili",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnnoDiCostruzione",
                table: "Immobili");

            migrationBuilder.DropColumn(
                name: "CateneCordoli",
                table: "Immobili");

            migrationBuilder.DropColumn(
                name: "Costruzione",
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
                name: "Uso",
                table: "Immobili");
        }
    }
}
