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
        [Route("api/verifica/{id}")]
        public async Task<dynamic> GetVerifica(int Id)
        {
            var utente = await _userManager.FindByNameAsync(User.Identity.Name);
            var immobile = await _db.Immobili.SingleAsync(im => im.Id == Id);
            if (immobile.UtenteAppartenenza.Id != utente.Id)
            {
                throw new Exception("Immobile non trovato");

            }
            else
            {
                var agibilità = Enum.GetValues(typeof(TipoAgibilita)).Cast<TipoAgibilita>().ToArray();

                return new
                {
                    Immobile = Mapper.Map<ImmobileDTO>(immobile),
                    MessaggioEsito = agibilità.ToString(),
                    CodiceEsito = agibilità[new Random().Next(agibilità.Length)]
                };
            }
        }
        [HttpGet]
        [Route("api/immobili/{id}")]
        public async Task<ImmobileDTO> GetImmobile(int Id)
        {
            var utente = await _userManager.FindByNameAsync(User.Identity.Name);
            var immobile = await _db.Immobili.SingleAsync(im => im.Id == Id);

            if (immobile.UtenteAppartenenza.Id != utente.Id)
            {
                throw new Exception("Immobile non trovato");

            }
            else
            {
                var result = Mapper.Map<ImmobileDTO>(immobile);
                var rnd = new Random();
                var rand = rnd.Next(1, 6);
                result.TipoAgibilita = ((TipoAgibilita)rand).ToString();
                return result;
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

        [HttpPut]
        [Route("api/segnalazione")]
        public async Task PostSegnalazione(SegnalazioneDTO segnalazione)
        {
            var utente = await _userManager.FindByNameAsync(User.Identity.Name);
            _db.Segnalazioni.Add(new Segnalazione
            {
                Descrizione = segnalazione.Descrizione,
                TipoSegnalazione = segnalazione.TipoSegnalazione,
                UtenteSegnalazione = utente
            });
            await _db.SaveChangesAsync();
        }

        [Route("api/topics")]
        public async Task<IEnumerable<TopicDTO>> GetTopics(string ricerca)
        {
            var result= _db.Topics.Where(t => t.Codice.Contains(ricerca)).Select(t=>Mapper.Map<TopicDTO>(t));
            
            await Task.FromResult(0);
            return result;
            
        }
        [Route("api/topics/{id}")]

        public async Task<TopicDTO> GetTopic(int Id)
        {
            var topic = await _db.Topics.SingleAsync(t => t.Id == Id);
            return Mapper.Map<TopicDTO>(topic);
        }
        [HttpPut]
        [Route("api/topic/addtopic")]
        public async Task<IActionResult> AddTopic(string topic)
        {
            if (topic.Length >= 2)
            {
                var utente = await _userManager.FindByNameAsync(User.Identity.Name);
                var roles = await _userManager.GetRolesAsync(utente);
                if (roles.Contains(Ruolo.PA.ToString()) || roles.Contains(Ruolo.ProtezioneCivile.ToString()))
                {
                    return InternalServerError(new Exception("Sessione scaduta"));
                }
                Topic NuovoTopic = new Topic();
                NuovoTopic.Codice = topic;
                Topic topicPresente = await _db.Topics.SingleOrDefaultAsync(t => t.Codice == topic);
                if (topicPresente != null)
                {
                    throw new Exception("Topic già presente");
                }
                else
                {
                    _db.Topics.Add(NuovoTopic);
                    _db.SaveChanges();
                }
                return Ok();
            }
            else
            {
                return new EmptyResult();
            }
        }
        [HttpDelete]
        [Route("api/topic/delete")]
        public async Task<IActionResult> RemoveTopic(int Id)
        {
            var utente = await _userManager.FindByNameAsync(User.Identity.Name);
            var roles = await _userManager.GetRolesAsync(utente);
            if (roles.Contains(Ruolo.PA.ToString())||roles.Contains(Ruolo.ProtezioneCivile.ToString()))
            {
                return InternalServerError(new Exception("Sessione scaduta"));
            }
            var topic = _db.Topics.Single(t => t.Id == Id);
            _db.Topics.Remove(topic);
            return Ok();
        }
        [HttpGet]
        [Route("api/avvisi/topic")]
        public async Task<IEnumerable<AvvisoDTO>> GetAvvisiByTopic(string ricerca)
        {
            await Task.FromResult(0);
            var avvisi = _db.Avvisi.Where(av => av.AvvisiTopics.Any(avt => avt.TopicRiferimento.Codice == ricerca));
            return avvisi.Select(av => Mapper.Map<AvvisoDTO>(av));
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
        public async Task<IEnumerable<dynamic>> GetAreeMappa()
        {
            throw new NotImplementedException();
            //return await _db.AreeMappa.Select(a => a.ToDTO()).ToListAsync();
        }

        [Route("api/gps")]
        public async Task PostGPS()
        {
            await Task.FromResult(0);
        }

        [Route("api/aziende/{pageNumber:int?}")]
        [HttpGet]
        public async Task<PagedResult<AziendaDTO>> GetAziende(int? pageNumber)
        {
            await Task.FromResult(0);
            int PageSize = 10;
            
            var skipValue = (pageNumber.GetValueOrDefault(1) - 1) * PageSize;
            var aziende = _db.Aziende.Skip(skipValue).Take(PageSize);

            var aziendeDTO=aziende.Select(az => Mapper.Map<AziendaDTO>(az));
            PagedResult<AziendaDTO> result = new PagedResult<AziendaDTO>();
            result.Risultati = aziendeDTO;
            result.PageNumber = pageNumber.GetValueOrDefault(1);
            return result;
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
