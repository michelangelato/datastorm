using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DataStorm.Web.Models;

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
            builder.Entity<Edificio>().ToTable("Edifici").HasKey(ed=>ed.Id);
            builder.Entity<Segnalazione>().ToTable("Segnalazioni").HasKey(s => s.Id);
            builder.Entity<Utente>().ToTable("Utenti").HasKey(user => user.Id);
            builder.Entity<Utente>().HasMany(ue => ue.AppartamentiUtente);
            builder.Entity<TipologiaEdificio>().ToTable("TipologieEdificio").HasKey(tipoed => tipoed.Id);
            builder.Entity<Appartamento>().ToTable("Appartamenti").HasKey(app => app.Id);
            builder.Entity<Appartamento>().HasOne(app => app.UtenteAppartenenza);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
