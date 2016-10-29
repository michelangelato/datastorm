using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataStorm.Web.Migrations
{
    public partial class RinominazioneImmobile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appartamenti_PuntiMappa_PuntoMappaId",
                table: "Appartamenti");

            migrationBuilder.DropForeignKey(
                name: "FK_Appartamenti_Utenti_UtenteAppartenenzaId",
                table: "Appartamenti");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appartamenti",
                table: "Appartamenti");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Immobili",
                table: "Appartamenti",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Immobili_PuntiMappa_PuntoMappaId",
                table: "Appartamenti",
                column: "PuntoMappaId",
                principalTable: "PuntiMappa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Immobili_Utenti_UtenteAppartenenzaId",
                table: "Appartamenti",
                column: "UtenteAppartenenzaId",
                principalTable: "Utenti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameIndex(
                name: "IX_Appartamenti_UtenteAppartenenzaId",
                table: "Appartamenti",
                newName: "IX_Immobili_UtenteAppartenenzaId");

            migrationBuilder.RenameIndex(
                name: "IX_Appartamenti_PuntoMappaId",
                table: "Appartamenti",
                newName: "IX_Immobili_PuntoMappaId");

            migrationBuilder.RenameTable(
                name: "Appartamenti",
                newName: "Immobili");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Immobili_PuntiMappa_PuntoMappaId",
                table: "Immobili");

            migrationBuilder.DropForeignKey(
                name: "FK_Immobili_Utenti_UtenteAppartenenzaId",
                table: "Immobili");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Immobili",
                table: "Immobili");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appartamenti",
                table: "Immobili",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appartamenti_PuntiMappa_PuntoMappaId",
                table: "Immobili",
                column: "PuntoMappaId",
                principalTable: "PuntiMappa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Appartamenti_Utenti_UtenteAppartenenzaId",
                table: "Immobili",
                column: "UtenteAppartenenzaId",
                principalTable: "Utenti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameIndex(
                name: "IX_Immobili_UtenteAppartenenzaId",
                table: "Immobili",
                newName: "IX_Appartamenti_UtenteAppartenenzaId");

            migrationBuilder.RenameIndex(
                name: "IX_Immobili_PuntoMappaId",
                table: "Immobili",
                newName: "IX_Appartamenti_PuntoMappaId");

            migrationBuilder.RenameTable(
                name: "Immobili",
                newName: "Appartamenti");
        }
    }
}
