using DataStorm.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStorm.Web.Data
{
    public static class DatabaseSeeder
    {
        private const string PASSWORD = "Datastorm!2016";

        private static Random Random = new Random();

        private static readonly TipologiaLavoro[] TipologieLavoroDefault =
        {
            new TipologiaLavoro {Codice="T01", Descrizione="Infissi" },
            new TipologiaLavoro {Codice="T02", Descrizione="Ristrutturazione edile" },
            new TipologiaLavoro {Codice="T03", Descrizione="Impiantistica" }
        };

        private static readonly Avviso[] AvvisiDefault =
        {
            new Avviso
            {
                Titolo = "Evacuazione centro storico Camerino",
                Descrizione = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum congue luctus dapibus. Integer ac porta lacus, ultricies aliquet purus. Etiam in ex mi. Duis commodo sit amet metus id consectetur. Aliquam mollis convallis vehicula. Morbi ultricies, dolor at condimentum mattis, arcu leo malesuada est, quis molestie ex mi id purus. Etiam auctor posuere auctor.",
                Links = new List<LinkAvviso>
                {
                    new LinkAvviso { Titolo = "Sito COC", Url="about:blank" }
                },
                ImmaginiAvviso = new List<ImmagineAvviso> { },
                AreeMappe = new List<AreaMappa>
                {
                    new AreaMappa
                    {
                        TipoMappa = TipoAreaMappa.Punto,
                        PuntiMappa = new List<PuntoMappa>
                        {
                            new PuntoMappa { LatitudinePunto=43.135700f, LongitudinePunto=13.068236f }
                        }
                    }
                }
            }
        };

        public static void Seed(this ApplicationDbContext db, UserManager<Utente> userManager, RoleManager<IdentityRole> roleManager)
        {
            using (var t = db.Database.BeginTransaction())
            {
                try
                {
                    Task.Run(() => db.SeedAsync(userManager, roleManager)).Wait();
                    t.Commit();
                }
                catch
                {
                    t.Rollback();
                }
            }
        }

        public static async Task SeedAsync(this ApplicationDbContext db, UserManager<Utente> userManager, RoleManager<IdentityRole> roleManager)
        {
            #region Seed Ruoli utente
            {
                var ruoli = Enum.GetValues(typeof(Ruolo)).Cast<Ruolo>();
                foreach (var ruolo in ruoli)
                {
                    var ruoloString = ruolo.ToString().ToLower();
                    var identityRole = await roleManager.FindByNameAsync(ruoloString);
                    if (identityRole == null)
                    {
                        identityRole = new IdentityRole { Name = ruoloString };
                        await roleManager.CreateAsync(identityRole);
                    }
                }
            }
            #endregion

            #region Seed Utenti
            {
                var ruoli = await roleManager.Roles.ToListAsync();
                foreach (var ruolo in ruoli)
                {
                    for (var i = 1; i <= 5; i++)
                    {
                        await userManager.CreaUtente($"{ruolo.Name}{i}@dominio.com", ruolo.Name);
                    }
                }
            }
            #endregion

            #region Seed Tipologie lavoro
            {
                foreach (var tipologiaLavoro in TipologieLavoroDefault)
                {
                    var tipologiaLavoroEsistente = await db.TipologieLavoro.FirstOrDefaultAsync(t => t.Codice == tipologiaLavoro.Codice);
                    if (tipologiaLavoroEsistente == null)
                    {
                        db.TipologieLavoro.Add(tipologiaLavoro);
                    }
                }

                await db.SaveChangesAsync();
            }
            #endregion

            #region Seed Aziende
            {
                if (!await db.Aziende.AnyAsync())
                {
                    var tipologieLavoro = await db.TipologieLavoro.ToListAsync();

                    for (var i = 1; i <= 20; i++)
                    {
                        var azienda = new Azienda
                        {
                            RagioneSociale = $"Azienda {i} S.p.A.",
                            PartitaIva = (123456789 + i).ToString(),
                            Citta = "Ancona",
                            Indirizzo = $"via Verdi {i}",
                            Posizione = await GetRandomPuntoRegioneMarche(),
                            AziendaTipoLavoro = new List<AziendeTipoLavoro>
                        {
                            new AziendeTipoLavoro
                            {
                                TipoLavoro=tipologieLavoro.ElementAt(Random.Next(0, tipologieLavoro.Count))
                            }
                        }
                        };

                        db.Aziende.Add(azienda);
                    }

                    await db.SaveChangesAsync();
                }
            }
            #endregion

            #region Seed Avvisi
            {
                foreach (var avviso in AvvisiDefault)
                {
                    var avvisoEsistente = await db.Avvisi.FirstOrDefaultAsync(a => a.Titolo == avviso.Titolo);
                    if (avvisoEsistente == null)
                    {
                        db.Avvisi.Add(avviso);
                    }
                }

                await db.SaveChangesAsync();
            }
            #endregion

            #region Seed Segnalazioni
            {/*
                if (!await db.Segnalazioni.AnyAsync())
                {
                    var tipologieSegnalazioni = Enum.GetValues(typeof(TipologiaSegnalazione)).Cast<TipologiaSegnalazione>().ToArray();

                    var utenti = await userManager.Users.ToListAsync();
                    foreach (var utente in utenti)
                    {
                        if (await userManager.IsInRoleAsync(utente, nameof(Ruolo.Cittadino)))
                        {
                            for (var i = 1; i <= 10; i++)
                            {
                                var segnalazione = new Segnalazione
                                {
                                    Descrizione = $"Segnalazione {i}",
                                    Localizzazione = await GetRandomPuntoRegioneMarche(),
                                    TipoSegnalazione = tipologieSegnalazioni[Random.Next(tipologieSegnalazioni.Length)],
                                    UtenteSegnalazione = utente
                                };

                                try
                                {
                                    db.Segnalazioni.Add(segnalazione);
                                }
                                catch (Exception ex)
                                {

                                }
                            }

                            await db.SaveChangesAsync();
                        }
                    }
                }*/
            }
            #endregion
        }

        private static async Task CreaUtente(this UserManager<Utente> userManager, string email, string ruolo)
        {
            var utente = await userManager.FindByEmailAsync(email);
            if (utente == null)
            {
                utente = new Utente
                {
                    UserName = email,
                    Email = email,
                    EmailConfirmed = true
                };

                var inserimentoUtente = await userManager.CreateAsync(utente, PASSWORD);
                if (!inserimentoUtente.Succeeded)
                {
                    throw new Exception($"SEED: si sono verificati i seguenti errori durante la creazione dell'utente {email}: {string.Join("; ", inserimentoUtente.Errors.Select(e => e.Description))}");
                }

                var aggiuntaRuolo = await userManager.AddToRoleAsync(utente, ruolo);
                if (!aggiuntaRuolo.Succeeded)
                {
                    throw new Exception($"SEED: si sono verificati i seguenti errori durante l'aggiunta del ruolo {ruolo} all'utente {email}: {string.Join("; ", inserimentoUtente.Errors.Select(e => e.Description))}");
                }
            }
        }

        private static async Task<PuntoMappa> GetRandomPuntoRegioneMarche()
        {
            var lat1 = 43.897875;
            var long1 = 12.803577;

            var lat2 = 42.927813;
            var long2 = 13.812921;

            return new PuntoMappa
            {
                LatitudinePunto = (float)(lat2 + (lat1 - lat2) * Random.NextDouble()),
                LongitudinePunto = (float)(long1 + (long2 - long1) * Random.NextDouble())
            };
        }
    }
}
