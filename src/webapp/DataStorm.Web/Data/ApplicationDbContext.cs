using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DataStorm.Web.Models;
using Npgsql;

namespace DataStorm.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<Utente>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            base.OnModelCreating(builder);
            builder.Entity<Segnalazione>().ToTable("Segnalazioni").HasKey(s => s.Id);
            builder.Entity<Utente>().ToTable("Utenti").HasKey(user => user.Id);
            builder.Entity<Utente>().HasMany(ue => ue.AppartamentiUtente);
            builder.Entity<Immobile>().ToTable("Immobili").HasKey(app => app.Id);
            builder.Entity<Immobile>().HasOne(app => app.PuntoMappa);
            builder.Entity<Immobile>().HasOne(app => app.UtenteAppartenenza);
            builder.Entity<LinkAvviso>().ToTable("LinkAvvisi").HasKey(lav => lav.Id);
            builder.Entity<ImmagineAvviso>().ToTable("ImmaginiAvvisi").HasKey(img => img.Id);
            builder.Entity<Avviso>().ToTable("Avvisi").HasKey(av => av.Id);
            builder.Entity<Avviso>().HasMany(av => av.ImmaginiAvviso);
            builder.Entity<Avviso>().HasMany(av => av.Links);
            builder.Entity<PuntoMappa>().ToTable("PuntiMappa").HasKey(pm => pm.Id);
            builder.Entity<AreaMappa>().ToTable("AreeMappa").HasKey(am=>am.Id);
            builder.Entity<AreaMappa>().HasMany(am => am.PuntiMappa);
            builder.Entity<Azienda>().ToTable("Aziende").HasKey(tl => tl.Id);
            builder.Entity<Azienda>().HasOne(az => az.Posizione);
            builder.Entity<TipologiaLavoro>().ToTable("TipologieLavoro").HasKey(tl=>tl.Id);
            builder.Entity<AziendeTipoLavoro>().ToTable("AziendeTipiLavoro").HasKey(tl => tl.Id);
            builder.Entity<AziendeTipoLavoro>().HasOne(az => az.AziendaLavoro);
            builder.Entity<AziendeTipoLavoro>().HasOne(tl => tl.TipoLavoro);
            builder.Entity<Azienda>().HasMany(az => az.AziendaTipoLavoro);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<Avviso> Avvisi { get; set; }
        public DbSet<Immobile> Immobili { get; set; }
        public DbSet<Utente> Utenti { get; set; }
    }
}
