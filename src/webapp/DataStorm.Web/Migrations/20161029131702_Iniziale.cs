using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataStorm.Web.Migrations
{
    public partial class Iniziale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Avvisi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Descrizione = table.Column<string>(nullable: true),
                    Titolo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avvisi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utenti",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utenti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "AreeMappa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    AvvisoId = table.Column<int>(nullable: true),
                    TipoMappa = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreeMappa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AreeMappa_Avvisi_AvvisoId",
                        column: x => x.AvvisoId,
                        principalTable: "Avvisi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImmaginiAvvisi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Altezza = table.Column<int>(nullable: false),
                    AvvisoId = table.Column<int>(nullable: true),
                    Larghezza = table.Column<int>(nullable: false),
                    TitoloImmagine = table.Column<string>(nullable: true),
                    UrlImmagine = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImmaginiAvvisi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImmaginiAvvisi_Avvisi_AvvisoId",
                        column: x => x.AvvisoId,
                        principalTable: "Avvisi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LinkAvvisi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    AvvisoId = table.Column<int>(nullable: true),
                    Titolo = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkAvvisi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LinkAvvisi_Avvisi_AvvisoId",
                        column: x => x.AvvisoId,
                        principalTable: "Avvisi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Segnalazioni",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    TipoSegnalazione = table.Column<int>(nullable: false),
                    UtenteSegnalazioneId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Segnalazioni", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Segnalazioni_Utenti_UtenteSegnalazioneId",
                        column: x => x.UtenteSegnalazioneId,
                        principalTable: "Utenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_Utenti_UserId",
                        column: x => x.UserId,
                        principalTable: "Utenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_Utenti_UserId",
                        column: x => x.UserId,
                        principalTable: "Utenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Utenti_UserId",
                        column: x => x.UserId,
                        principalTable: "Utenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PuntiMappa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    AreaMappaId = table.Column<int>(nullable: true),
                    LatitudinePunto = table.Column<float>(nullable: false),
                    LongitudinePunto = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PuntiMappa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PuntiMappa_AreeMappa_AreaMappaId",
                        column: x => x.AreaMappaId,
                        principalTable: "AreeMappa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Appartamenti",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    MetriQuadri = table.Column<decimal>(nullable: false),
                    PuntoMappaId = table.Column<int>(nullable: true),
                    UtenteAppartenenzaId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appartamenti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appartamenti_PuntiMappa_PuntoMappaId",
                        column: x => x.PuntoMappaId,
                        principalTable: "PuntiMappa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appartamenti_Utenti_UtenteAppartenenzaId",
                        column: x => x.UtenteAppartenenzaId,
                        principalTable: "Utenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Edifici",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    AppartamentoEdifcioId = table.Column<int>(nullable: true),
                    Comune = table.Column<string>(nullable: true),
                    Indirizzo = table.Column<string>(nullable: true),
                    NumeroPersoneResidenti = table.Column<short>(nullable: false),
                    Provincia = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edifici", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edifici_Appartamenti_AppartamentoEdifcioId",
                        column: x => x.AppartamentoEdifcioId,
                        principalTable: "Appartamenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appartamenti_PuntoMappaId",
                table: "Appartamenti",
                column: "PuntoMappaId");

            migrationBuilder.CreateIndex(
                name: "IX_Appartamenti_UtenteAppartenenzaId",
                table: "Appartamenti",
                column: "UtenteAppartenenzaId");

            migrationBuilder.CreateIndex(
                name: "IX_AreeMappa_AvvisoId",
                table: "AreeMappa",
                column: "AvvisoId");

            migrationBuilder.CreateIndex(
                name: "IX_Edifici_AppartamentoEdifcioId",
                table: "Edifici",
                column: "AppartamentoEdifcioId");

            migrationBuilder.CreateIndex(
                name: "IX_ImmaginiAvvisi_AvvisoId",
                table: "ImmaginiAvvisi",
                column: "AvvisoId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkAvvisi_AvvisoId",
                table: "LinkAvvisi",
                column: "AvvisoId");

            migrationBuilder.CreateIndex(
                name: "IX_PuntiMappa_AreaMappaId",
                table: "PuntiMappa",
                column: "AreaMappaId");

            migrationBuilder.CreateIndex(
                name: "IX_Segnalazioni_UtenteSegnalazioneId",
                table: "Segnalazioni",
                column: "UtenteSegnalazioneId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Utenti",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Utenti",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Edifici");

            migrationBuilder.DropTable(
                name: "ImmaginiAvvisi");

            migrationBuilder.DropTable(
                name: "LinkAvvisi");

            migrationBuilder.DropTable(
                name: "Segnalazioni");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Appartamenti");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "PuntiMappa");

            migrationBuilder.DropTable(
                name: "Utenti");

            migrationBuilder.DropTable(
                name: "AreeMappa");

            migrationBuilder.DropTable(
                name: "Avvisi");
        }
    }
}
