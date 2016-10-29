using DataStorm.Web.Data;
using DataStorm.Web.Models;
using DataStorm.Web.Models.DTO;
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
        private ApplicationDbContext db;

        public WebApiController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [Route("api/immobile")]
        public async Task PostImmobile(ImmobileDTO immobile)
        {
            db.Immobili.Add(new Immobile
            {
                Comune = immobile.Comune,
                Indirizzo = immobile.Indirizzo,
                MetriQuadri = immobile.MetriQuadri,
                NumeroPersoneResidenti = immobile.NumeroPersoneResidenti,
                NumeroPiano = immobile.NumeroPiano,
                PuntoMappa = new PuntoMappa { LatitudinePunto = immobile.LatitudinePunto, LongitudinePunto = immobile.LongitudinePunto },
                TipoImmobile = immobile.TipoImmobile,
#warning TODO
                UtenteAppartenenza = null
            });

            await db.SaveChangesAsync();
        }

        [Route("api/immobili")]
        public async Task<IEnumerable<ImmobileDTO>> GetImmobili()
        {
            return await db.Immobili.Select(i => new ImmobileDTO
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
        public async Task<object> GetAvvisi()
        {
            return await Task.FromResult(0);
        }

        [Route("api/avvisi/{id}")]
        public async Task<object> GetAvviso(int ID)
        {
            return await Task.FromResult(0);
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

        [Route("api/oggetti-mappa")]
        public async Task<IEnumerable<AreaMappa>> GetOggettiMappa()
        {
            await Task.FromResult(0);
            return null;
        }

        [Route("api/gps")]
        public async Task PostGPS()
        {
            await Task.FromResult(0);
        }
    }
}
