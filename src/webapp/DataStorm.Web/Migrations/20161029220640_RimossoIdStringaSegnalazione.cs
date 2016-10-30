using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataStorm.Web.Migrations
{
    public partial class RimossoIdStringaSegnalazione : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Segnalazioni",
                table: "Segnalazioni");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Segnalazioni");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Segnalazioni",
                table: "Segnalazioni",
                column: "TipoSegnalazione");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Segnalazioni",
                table: "Segnalazioni");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Segnalazioni",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Segnalazioni",
                table: "Segnalazioni",
                column: "Id");
        }
    }
}
