using DataStorm.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DataStorm.Web.Data
{
    public static class DatabaseSeeder
    {
        private const string PASSWORD = "Datastorm!2016";

        private static Random Random = new Random();

        private static string[] TopicsEsempio = new string[] { "Terremoto Amatrice", "Terremoto 26 ottobre 2016", "Emergenza Camerino", "Arquata del Tronto" };

        private static readonly TipologiaLavoro[] TipologieLavoroDefault =
        {
            new TipologiaLavoro {Codice="T01", Descrizione="Infissi" },
            new TipologiaLavoro {Codice="T02", Descrizione="Ristrutturazione edile" },
            new TipologiaLavoro {Codice="T03", Descrizione="Impiantistica" }
        };

        private static readonly ImmagineAvviso[] ImmaginiEsempio =
        {
            new ImmagineAvviso { TitoloImmagine="Amatrice", UrlImmagine="http://www.repstatic.it/video/photo/2016/08/31/339301/339301-thumb-full-zonarossaamtrice.jpg", Larghezza=640, Altezza=360 },
            new ImmagineAvviso { TitoloImmagine="Camerino", UrlImmagine="https://www.repstatic.it/content/nazionale/img/2016/10/26/220243584-8de1ce9e-d984-466c-89dd-990920525a6a.jpg", Larghezza=880, Altezza=660 },
            new ImmagineAvviso { TitoloImmagine="Ipocentro", UrlImmagine="http://www.meteoweb.eu/wp-content/uploads/2014/03/epicentro_ipocentro.jpg", Larghezza=299, Altezza=236 }
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
                    var ruoloString = Enum.GetName(typeof(Ruolo), ruolo);
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
                        await userManager.CreaUtente(db, $"{ruolo.Name}{i}@dastastorm.com", ruolo.Name);
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

            #region Seed Topics
            {
                foreach (var topic in TopicsEsempio)
                {
                    if (!await db.Topics.AnyAsync(t => t.Codice == topic))
                    {
                        db.Topics.Add(new Topic { Codice = topic });
                    }
                }

                await db.SaveChangesAsync();
            }
            #endregion

            #region Seed Avvisi
            {
                var topics = await db.Topics.ToListAsync();

                foreach (var topic in topics)
                {
                    for (var i = 1; i <= 100; i++)
                    {
                        var avviso = new Avviso
                        {
                            Titolo = $"Avviso {topic.Codice} {i}",
                            Descrizione = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum congue luctus dapibus. Integer ac porta lacus, ultricies aliquet purus. Etiam in ex mi. Duis commodo sit amet metus id consectetur. Aliquam mollis convallis vehicula. Morbi ultricies, dolor at condimentum mattis, arcu leo malesuada est, quis molestie ex mi id purus. Etiam auctor posuere auctor.",
                            Links = await GetLinkEsempio(),
                            ImmaginiAvviso = await GetImmaginiEsempio(),
                            AreeMappe = new List<AreaMappa>
                            {
                                new AreaMappa
                                {
                                    TipoMappa = TipoAreaMappa.Punto,
                                    PuntiMappa = new List<PuntoMappa> { await GetRandomPuntoRegioneMarche() }
                                }
                            }
                        };

                        avviso.AvvisiTopics = new List<AvvisoTopic> { new AvvisoTopic { AvvisoRiferimento = avviso, TopicRiferimento = topic } };

                        if (!await db.Avvisi.AnyAsync(a => a.Titolo == avviso.Titolo))
                        {
                            db.Avvisi.Add(avviso);
                        }
                    }
                }

                await db.SaveChangesAsync();
            }
            #endregion

            #region Seed Segnalazioni
            {
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

                                db.Segnalazioni.Add(segnalazione);
                            }

                            await db.SaveChangesAsync();
                        }
                    }
                }
            }
            #endregion
        }

        private static async Task CreaUtente(this UserManager<Utente> userManager, ApplicationDbContext db, string email, string ruolo)
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

        private static async Task<List<LinkAvviso>> GetLinkEsempio()
        {
            var lista = new List<LinkAvviso>();

            var n = Random.Next(4);
            for (var i = 1; i <= n; i++)
            {
                lista.Add(new LinkAvviso { Titolo = $"Link {i}", Url = "about:blank" });
            }

            return lista;
        }

        private static async Task<List<ImmagineAvviso>> GetImmaginiEsempio()
        {
            var lista = new List<ImmagineAvviso>();

            var n = Random.Next(3);
            for (var i = 1; i <= n; i++)
            {
                var immagine = ImmaginiEsempio[Random.Next(ImmaginiEsempio.Length)];
                lista.Add(new ImmagineAvviso
                {
                    TitoloImmagine = immagine.TitoloImmagine,
                    UrlImmagine = immagine.UrlImmagine,
                    Larghezza = immagine.Larghezza,
                    Altezza = immagine.Altezza
                });
            }

            return lista;
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
