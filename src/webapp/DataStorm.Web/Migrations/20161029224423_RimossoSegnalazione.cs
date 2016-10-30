using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataStorm.Web.Migrations
{
    public partial class RimossoSegnalazione : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Segnalazioni");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Segnalazioni",
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
                    table.PrimaryKey("PK_Segnalazioni", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Segnalazioni_PuntiMappa_LocalizzazioneId",
                        column: x => x.LocalizzazioneId,
                        principalTable: "PuntiMappa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Segnalazioni_Utenti_UtenteSegnalazioneId",
                        column: x => x.UtenteSegnalazioneId,
                        principalTable: "Utenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Segnalazioni_LocalizzazioneId",
                table: "Segnalazioni",
                column: "LocalizzazioneId");

            migrationBuilder.CreateIndex(
                name: "IX_Segnalazioni_UtenteSegnalazioneId",
                table: "Segnalazioni",
                column: "UtenteSegnalazioneId");
        }
    }
}
