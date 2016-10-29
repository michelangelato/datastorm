using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataStorm.Web.Migrations
{
    public partial class CorrezioneTopic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Topics_Avvisi_AvvisoId",
                table: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_Topics_AvvisoId",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "AvvisoId",
                table: "Topics");

            migrationBuilder.CreateTable(
                name: "AvvisiTopics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    AvvisoRiferimentoId = table.Column<int>(nullable: true),
                    TopicRiferimentoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvvisiTopics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvvisiTopics_Avvisi_AvvisoRiferimentoId",
                        column: x => x.AvvisoRiferimentoId,
                        principalTable: "Avvisi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AvvisiTopics_Topics_TopicRiferimentoId",
                        column: x => x.TopicRiferimentoId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvvisiTopics_AvvisoRiferimentoId",
                table: "AvvisiTopics",
                column: "AvvisoRiferimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_AvvisiTopics_TopicRiferimentoId",
                table: "AvvisiTopics",
                column: "TopicRiferimentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvvisiTopics");

            migrationBuilder.AddColumn<int>(
                name: "AvvisoId",
                table: "Topics",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Topics_AvvisoId",
                table: "Topics",
                column: "AvvisoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_Avvisi_AvvisoId",
                table: "Topics",
                column: "AvvisoId",
                principalTable: "Avvisi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
