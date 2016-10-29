using AutoMapper;
using DataStorm.Web.Data;
using DataStorm.Web.Models;
using DataStorm.Web.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
        private readonly ApplicationDbContext _db;
        private readonly UserManager<Utente> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public WebApiController(ApplicationDbContext db, UserManager<Utente> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;

            db.Seed(userManager, roleManager);
        }

        [Authorize]
        [Route("api/putimmobile")]
        [HttpPut]
        public async Task PutImmobile(ImmobileDTO immobile)
        {
            try
            {
                var utente = await _userManager.FindByNameAsync(User.Identity.Name);
                Immobile nuovoImmobile = Mapper.Map<ImmobileDTO, Immobile>(immobile);
                nuovoImmobile.UtenteAppartenenza = utente;
                _db.Immobili.Add(
                    nuovoImmobile
                    );

                await _db.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ActionResult> EditImmobile(ImmobileDTO immobile)
        {
            var utente = await _userManager.FindByNameAsync(User.Identity.Name);
            
            Immobile immobileCoinvolto = _db.Immobili.Single(i => i.Id == immobile.Id);
            if (immobileCoinvolto.UtenteAppartenenza.Id != utente.Id)
            {
                return InternalServerError(new Exception("Immobile non valido"));
            }
            Mapper.Map(immobile, immobileCoinvolto);
            await _db.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteImmobile(int Id)
        {
            var utente = await _userManager.FindByNameAsync(User.Identity.Name);

            Immobile immobileCoinvolto = _db.Immobili.Single(i => i.Id == Id);
            if (immobileCoinvolto.UtenteAppartenenza.Id != utente.Id)
            {
                return InternalServerError(new Exception("Immobile non valido"));
            }
            else
            {
                _db.Immobili.Remove(immobileCoinvolto);
            }
            return Ok();
        }
        [HttpGet]
        [Route("api/immobili/{id}")]
        public async Task<ImmobileDTO> GetImmobile(int Id)
        {
            var utente = await _userManager.FindByNameAsync(User.Identity.Name);
            var immobile = await _db.Immobili.SingleAsync(im => im.Id == Id);
            if(immobile.UtenteAppartenenza.Id!=utente.Id)
            {
                throw new Exception("Immobile non trovato");
                
            }
            else
            {
                return Mapper.Map<ImmobileDTO>(immobile);
            }
        }
        [Authorize]
        [Route("api/immobili")]
        public async Task<IEnumerable<ImmobileDTO>> GetImmobili()
        {
            var utente = await _userManager.FindByNameAsync(User.Identity.Name);

            return await _db.Immobili
                .Where(i => i.UtenteAppartenenza == utente)
                .Select(i => 
                    Mapper.Map<ImmobileDTO>(i)
                ).ToListAsync();
        }

        [Route("api/immobili/tipologie")]
        public async Task<IEnumerable<KeyValuePair<int, string>>> GetTipologieImmobili()
        {
            await Task.FromResult(0);
            var tipologie = Enum.GetValues(typeof(TipologiaImmobile)).Cast<TipologiaImmobile>().ToArray();
            return tipologie.Select(t => new KeyValuePair<int, string>((int)t, t.ToString()));
        }
        [HttpGet]
        [Route("api/avvisi")]
        public async Task<IEnumerable<AvvisoDTO>> GetAvvisi()
        {

            var avvisi = _db.Avvisi.Select(av=>Mapper.Map<AvvisoDTO>(av));
            await Task.FromResult(0);
            return avvisi;
            //return await _db.Avvisi.Select(a => a.ToDTO()).ToListAsync();
        }

        [Route("api/avvisi/{id}")]
        [HttpGet]
        public async Task<AvvisoDTO> GetAvviso(int Id)
        {
            var avviso = await _db.Avvisi.SingleAsync(a => a.Id == Id);
            return Mapper.Map<AvvisoDTO>(avviso);
            //return await _db.Avvisi.First(a => a.Id == ID).ToDTO();
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
            throw new NotImplementedException();
            //return await _db.AreeMappa.Select(a => a.ToDTO()).ToListAsync();
        }

        [Route("api/gps")]
        public async Task PostGPS()
        {
            await Task.FromResult(0);
        }
        //[Route("api/automapper")]
        //public async Task<ImmobileDTO> ProvaAutoMapper()
        //{
        //    await Task.FromResult(0);

        //    Immobile ImmobileTest = new Immobile();
        //    ImmobileTest.Indirizzo = "aaaaa";
        //    var mapped= Mapper.Map<Immobile, ImmobileDTO>(ImmobileTest);
        //    return mapped;
        //}
        [Route("api/aziende/{pageNumber:int?}")]
        [HttpGet]
        public async Task<IEnumerable<AziendaDTO>> GetAziende(int? pageNumber)
        {
            await Task.FromResult(0);
            int PageSize = 10;
            
            var skipValue = (pageNumber.GetValueOrDefault(1) - 1) * PageSize;
            var aziende = _db.Aziende.Skip(skipValue).Take(PageSize);
            return aziende.Select(az => Mapper.Map<AziendaDTO>(az));
        }
        [Route("api/aziende/{id}")]
        [HttpGet]
        public async Task<AziendaDTO> GetAzienda(int idAzienda)
        {
            var azienda = await _db.Aziende.SingleAsync(az => az.Id == idAzienda);
            return Mapper.Map<Azienda, AziendaDTO>(azienda);
        }
    }
}
