using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DataStorm.Web.Data;

namespace DataStorm.Web.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20161029165633_Catasto")]
    partial class Catasto
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1");

            modelBuilder.Entity("DataStorm.Web.Models.AreaMappa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AvvisoId");

                    b.Property<int>("TipoMappa");

                    b.HasKey("Id");

                    b.HasIndex("AvvisoId");

                    b.ToTable("AreeMappa");
                });

            modelBuilder.Entity("DataStorm.Web.Models.Avviso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descrizione");

                    b.Property<string>("Titolo");

                    b.HasKey("Id");

                    b.ToTable("Avvisi");
                });

            modelBuilder.Entity("DataStorm.Web.Models.Azienda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Citta");

                    b.Property<string>("Indirizzo");

                    b.Property<string>("PartitaIva");

                    b.Property<int?>("PosizioneId");

                    b.Property<string>("RagioneSociale");

                    b.HasKey("Id");

                    b.HasIndex("PosizioneId");

                    b.ToTable("Aziende");
                });

            modelBuilder.Entity("DataStorm.Web.Models.AziendeTipoLavoro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AziendaId");

                    b.Property<int?>("AziendaLavoroId");

                    b.Property<int?>("TipoLavoroId");

                    b.HasKey("Id");

                    b.HasIndex("AziendaId");

                    b.HasIndex("AziendaLavoroId");

                    b.HasIndex("TipoLavoroId");

                    b.ToTable("AziendeTipiLavoro");
                });

            modelBuilder.Entity("DataStorm.Web.Models.Catasto", b =>
                {
                    b.Property<int>("IdCatasto")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AnnoDiCostruzione");

                    b.Property<int>("AreaInMq");

                    b.Property<int>("CateneCordoli");

                    b.Property<string>("Comune");

                    b.Property<int>("Costruzione");

                    b.Property<int>("DissestiTerreno");

                    b.Property<string>("Indirizzo");

                    b.Property<int>("NumeroDiPiani");

                    b.Property<int>("PercentualeUtilizzo");

                    b.Property<int>("Posizione");

                    b.Property<int>("Proprieta");

                    b.Property<int?>("PuntoMappaId");

                    b.Property<int>("Terreno");

                    b.Property<int>("Uso");

                    b.HasKey("IdCatasto");

                    b.HasIndex("PuntoMappaId");

                    b.ToTable("Catasto");
                });

            modelBuilder.Entity("DataStorm.Web.Models.ImmagineAvviso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Altezza");

                    b.Property<int?>("AvvisoId");

                    b.Property<int>("Larghezza");

                    b.Property<string>("TitoloImmagine");

                    b.Property<string>("UrlImmagine");

                    b.HasKey("Id");

                    b.HasIndex("AvvisoId");

                    b.ToTable("ImmaginiAvvisi");
                });

            modelBuilder.Entity("DataStorm.Web.Models.Immobile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AnnoDiCostruzione");

                    b.Property<int>("AreaInMq");

                    b.Property<int>("CateneCordoli");

                    b.Property<string>("Comune");

                    b.Property<int>("Costruzione");

                    b.Property<int>("DissestiTerreno");

                    b.Property<string>("Indirizzo");

                    b.Property<int>("NumeroDiPiani");

                    b.Property<int>("PercentualeUtilizzo");

                    b.Property<int>("Posizione");

                    b.Property<int>("Proprieta");

                    b.Property<int?>("PuntoMappaId");

                    b.Property<int>("Terreno");

                    b.Property<int>("TipoImmobile");

                    b.Property<int>("Uso");

                    b.Property<string>("UtenteAppartenenzaId");

                    b.HasKey("Id");

                    b.HasIndex("PuntoMappaId");

                    b.HasIndex("UtenteAppartenenzaId");

                    b.ToTable("Immobili");
                });

            modelBuilder.Entity("DataStorm.Web.Models.LinkAvviso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AvvisoId");

                    b.Property<string>("Titolo");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("AvvisoId");

                    b.ToTable("LinkAvvisi");
                });

            modelBuilder.Entity("DataStorm.Web.Models.PuntoMappa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AreaMappaId");

                    b.Property<float>("LatitudinePunto");

                    b.Property<float>("LongitudinePunto");

                    b.HasKey("Id");

                    b.HasIndex("AreaMappaId");

                    b.ToTable("PuntiMappa");
                });

            modelBuilder.Entity("DataStorm.Web.Models.Segnalazione", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("Descrizione");

                    b.Property<int?>("LocalizzazioneId");

                    b.Property<int>("TipoSegnalazione");

                    b.Property<string>("UtenteSegnalazioneId");

                    b.HasKey("Id");

                    b.HasIndex("LocalizzazioneId");

                    b.HasIndex("UtenteSegnalazioneId");

                    b.ToTable("Segnalazioni");
                });

            modelBuilder.Entity("DataStorm.Web.Models.TipologiaLavoro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Codice");

                    b.Property<string>("Descrizione");

                    b.HasKey("Id");

                    b.ToTable("TipologieLavoro");
                });

            modelBuilder.Entity("DataStorm.Web.Models.Utente", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("Utenti");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("DataStorm.Web.Models.AreaMappa", b =>
                {
                    b.HasOne("DataStorm.Web.Models.Avviso")
                        .WithMany("AreeMappe")
                        .HasForeignKey("AvvisoId");
                });

            modelBuilder.Entity("DataStorm.Web.Models.Azienda", b =>
                {
                    b.HasOne("DataStorm.Web.Models.PuntoMappa", "Posizione")
                        .WithMany()
                        .HasForeignKey("PosizioneId");
                });

            modelBuilder.Entity("DataStorm.Web.Models.AziendeTipoLavoro", b =>
                {
                    b.HasOne("DataStorm.Web.Models.Azienda")
                        .WithMany("AziendaTipoLavoro")
                        .HasForeignKey("AziendaId");

                    b.HasOne("DataStorm.Web.Models.Azienda", "AziendaLavoro")
                        .WithMany()
                        .HasForeignKey("AziendaLavoroId");

                    b.HasOne("DataStorm.Web.Models.TipologiaLavoro", "TipoLavoro")
                        .WithMany()
                        .HasForeignKey("TipoLavoroId");
                });

            modelBuilder.Entity("DataStorm.Web.Models.Catasto", b =>
                {
                    b.HasOne("DataStorm.Web.Models.PuntoMappa", "PuntoMappa")
                        .WithMany()
                        .HasForeignKey("PuntoMappaId");
                });

            modelBuilder.Entity("DataStorm.Web.Models.ImmagineAvviso", b =>
                {
                    b.HasOne("DataStorm.Web.Models.Avviso")
                        .WithMany("ImmaginiAvviso")
                        .HasForeignKey("AvvisoId");
                });

            modelBuilder.Entity("DataStorm.Web.Models.Immobile", b =>
                {
                    b.HasOne("DataStorm.Web.Models.PuntoMappa", "PuntoMappa")
                        .WithMany()
                        .HasForeignKey("PuntoMappaId");

                    b.HasOne("DataStorm.Web.Models.Utente", "UtenteAppartenenza")
                        .WithMany("AppartamentiUtente")
                        .HasForeignKey("UtenteAppartenenzaId");
                });

            modelBuilder.Entity("DataStorm.Web.Models.LinkAvviso", b =>
                {
                    b.HasOne("DataStorm.Web.Models.Avviso")
                        .WithMany("Links")
                        .HasForeignKey("AvvisoId");
                });

            modelBuilder.Entity("DataStorm.Web.Models.PuntoMappa", b =>
                {
                    b.HasOne("DataStorm.Web.Models.AreaMappa")
                        .WithMany("PuntiMappa")
                        .HasForeignKey("AreaMappaId");
                });

            modelBuilder.Entity("DataStorm.Web.Models.Segnalazione", b =>
                {
                    b.HasOne("DataStorm.Web.Models.PuntoMappa", "Localizzazione")
                        .WithMany()
                        .HasForeignKey("LocalizzazioneId");

                    b.HasOne("DataStorm.Web.Models.Utente", "UtenteSegnalazione")
                        .WithMany()
                        .HasForeignKey("UtenteSegnalazioneId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("DataStorm.Web.Models.Utente")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DataStorm.Web.Models.Utente")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataStorm.Web.Models.Utente")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
