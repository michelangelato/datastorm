using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataStorm.Web.Migrations
{
    public partial class FixComuni : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Regioni",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Denominazione",
                table: "Province",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Sigla",
                table: "Province",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Denominazione",
                table: "Comuni",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Regioni",
                maxLength: 40,
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Denominazione",
                table: "Province",
                maxLength: 40,
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Sigla",
                table: "Province",
                type: "char",
                maxLength: 2,
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Denominazione",
                table: "Comuni",
                maxLength: 40,
                nullable: false);
        }
    }
}
