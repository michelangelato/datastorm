using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using DataStorm.Web.Models;

namespace DataStorm.Web.Migrations
{
    public partial class AddColonnaTipoAgibilita : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "TipoAgibilita",
                table: "Immobili",
                nullable: false,
                defaultValue: TipoAgibilita.InformazioneMancante);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoAgibilita",
                table: "Immobili");

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
        }
    }
}
