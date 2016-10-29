using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataStorm.Web.Migrations
{
    public partial class AggiuntaProprietaSegnalazione : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descrizione",
                table: "Segnalazioni",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocalizzazioneId",
                table: "Segnalazioni",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Segnalazioni_LocalizzazioneId",
                table: "Segnalazioni",
                column: "LocalizzazioneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Segnalazioni_PuntiMappa_LocalizzazioneId",
                table: "Segnalazioni",
                column: "LocalizzazioneId",
                principalTable: "PuntiMappa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Segnalazioni_PuntiMappa_LocalizzazioneId",
                table: "Segnalazioni");

            migrationBuilder.DropIndex(
                name: "IX_Segnalazioni_LocalizzazioneId",
                table: "Segnalazioni");

            migrationBuilder.DropColumn(
                name: "Descrizione",
                table: "Segnalazioni");

            migrationBuilder.DropColumn(
                name: "LocalizzazioneId",
                table: "Segnalazioni");
        }
    }
}
