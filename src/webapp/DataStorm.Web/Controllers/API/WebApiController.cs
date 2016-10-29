using AutoMapper;
using DataStorm.Web.Data;
using DataStorm.Web.Models;
using DataStorm.Web.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace DataStorm.Web.Controllers.API
{
    public class WebApiController : ApiController
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<Utente> um;

        public WebApiController(ApplicationDbContext db, UserManager<Utente> um)
        {
            this.db = db;
            this.um = um;
        }

        [Authorize]
        [Route("api/immobile")]
        public async Task PostImmobile(ImmobileDTO immobile)
        {
            var utente = await um.FindByNameAsync(User.Identity.Name);

            db.Immobili.Add(new Immobile
            {
                Comune = immobile.Comune,
                Indirizzo = immobile.Indirizzo,
                MetriQuadri = immobile.MetriQuadri,
                NumeroPersoneResidenti = immobile.NumeroPersoneResidenti,
                NumeroPiano = immobile.NumeroPiano,
                PuntoMappa = new PuntoMappa { LatitudinePunto = immobile.LatitudinePunto, LongitudinePunto = immobile.LongitudinePunto },
                TipoImmobile = immobile.TipoImmobile,
                UtenteAppartenenza = utente
            });

            await db.SaveChangesAsync();
        }

        [Authorize]
        [Route("api/immobili")]
        public async Task<IEnumerable<ImmobileDTO>> GetImmobili()
        {
            var utente = await um.FindByNameAsync(User.Identity.Name);

            return await db.Immobili
                .Where(i => i.UtenteAppartenenza == utente)
                .Select(i => new ImmobileDTO
                {
                    Comune = i.Comune,
                    Indirizzo = i.Indirizzo,
                    LatitudinePunto = i.PuntoMappa.LatitudinePunto,
                    LongitudinePunto = i.PuntoMappa.LongitudinePunto,
                    MetriQuadri = i.MetriQuadri,
                    NumeroPersoneResidenti = i.NumeroPersoneResidenti,
                    NumeroPiano = i.NumeroPiano,
                    TipoImmobile = i.TipoImmobile
                }).ToListAsync();
        }

        [Route("api/immobili/tipologie")]
        public async Task<IEnumerable<KeyValuePair<int, string>>> GetTipologieImmobili()
        {
            var tipologie = Enum.GetValues(typeof(TipologiaImmobile)).Cast<TipologiaImmobile>().ToArray();
            return tipologie.Select(t => new KeyValuePair<int, string>((int)t, t.ToString()));
        }

        [Route("api/avvisi")]
        public async Task<dynamic> GetAvvisi()
        {
            return await db.Avvisi.Select(a => a.ToDTO()).ToListAsync();
        }

        [Route("api/avvisi/{id}")]
        public async Task<dynamic> GetAvviso(int ID)
        {
            return await db.Avvisi.First(a => a.Id == ID).ToDTO();
        }

        [Route("api/segnalazione")]
        public async Task PostSegnalazione()
        {
            await Task.FromResult(0);
        }

        [Route("api/richiesta")]
        public async Task PostRichiesta()
        {
            await Task.FromResult(0);
        }

        [Route("api/richieste")]
        public async Task<IEnumerable<string>> GetRichieste()
        {
            await Task.FromResult(0);
            return null;
        }

        [Route("api/elementi-mappa")]
        public async Task<IEnumerable<dynamic>> GetElementiMappa()
        {
            return await db.AreeMappa.Select(a => a.ToDTO()).ToListAsync();
        }

        [Route("api/gps")]
        public async Task PostGPS()
        {
            await Task.FromResult(0);
        }
        [Route("api/automapper")]
        public async Task<ImmobileDTO> ProvaAutoMapper()
        {
            await Task.FromResult(0);

            Immobile ImmobileTest = new Immobile();
            ImmobileTest.Indirizzo = "aaaaa";
            var mapped= Mapper.Map<Immobile, ImmobileDTO>(ImmobileTest);
            return mapped;
        }
    }
}
