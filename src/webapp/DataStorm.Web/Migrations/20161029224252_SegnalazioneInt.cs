using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataStorm.Web.Migrations
{
    public partial class SegnalazioneInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SegnalazioniInt",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Descrizione = table.Column<string>(nullable: true),
                    LocalizzazioneId = table.Column<int>(nullable: true),
                    TipoSegnalazione = table.Column<int>(nullable: false),
                    UtenteSegnalazioneId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SegnalazioniInt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SegnalazioniInt_PuntiMappa_LocalizzazioneId",
                        column: x => x.LocalizzazioneId,
                        principalTable: "PuntiMappa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SegnalazioniInt_Utenti_UtenteSegnalazioneId",
                        column: x => x.UtenteSegnalazioneId,
                        principalTable: "Utenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SegnalazioniInt_LocalizzazioneId",
                table: "SegnalazioniInt",
                column: "LocalizzazioneId");

            migrationBuilder.CreateIndex(
                name: "IX_SegnalazioniInt_UtenteSegnalazioneId",
                table: "SegnalazioniInt",
                column: "UtenteSegnalazioneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SegnalazioniInt");
        }
    }
}
