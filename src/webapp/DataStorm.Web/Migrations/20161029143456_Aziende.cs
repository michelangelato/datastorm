using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataStorm.Web.Migrations
{
    public partial class Aziende : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aziende",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Citta = table.Column<string>(nullable: true),
                    Indirizzo = table.Column<string>(nullable: true),
                    PartitaIva = table.Column<string>(nullable: true),
                    PosizioneId = table.Column<int>(nullable: true),
                    RagioneSociale = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aziende", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aziende_PuntiMappa_PosizioneId",
                        column: x => x.PosizioneId,
                        principalTable: "PuntiMappa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TipologieLavoro",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Codice = table.Column<string>(nullable: true),
                    Descrizione = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipologieLavoro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AziendeTipiLavoro",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    AziendaId = table.Column<int>(nullable: true),
                    AziendaLavoroId = table.Column<int>(nullable: true),
                    TipoLavoroId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AziendeTipiLavoro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AziendeTipiLavoro_Aziende_AziendaId",
                        column: x => x.AziendaId,
                        principalTable: "Aziende",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AziendeTipiLavoro_Aziende_AziendaLavoroId",
                        column: x => x.AziendaLavoroId,
                        principalTable: "Aziende",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AziendeTipiLavoro_TipologieLavoro_TipoLavoroId",
                        column: x => x.TipoLavoroId,
                        principalTable: "TipologieLavoro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aziende_PosizioneId",
                table: "Aziende",
                column: "PosizioneId");

            migrationBuilder.CreateIndex(
                name: "IX_AziendeTipiLavoro_AziendaId",
                table: "AziendeTipiLavoro",
                column: "AziendaId");

            migrationBuilder.CreateIndex(
                name: "IX_AziendeTipiLavoro_AziendaLavoroId",
                table: "AziendeTipiLavoro",
                column: "AziendaLavoroId");

            migrationBuilder.CreateIndex(
                name: "IX_AziendeTipiLavoro_TipoLavoroId",
                table: "AziendeTipiLavoro",
                column: "TipoLavoroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AziendeTipiLavoro");

            migrationBuilder.DropTable(
                name: "Aziende");

            migrationBuilder.DropTable(
                name: "TipologieLavoro");
        }
    }
}
