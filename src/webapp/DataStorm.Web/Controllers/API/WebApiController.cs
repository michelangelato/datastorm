using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace DataStorm.Web.Controllers.API
{
    public class WebApiController : ApiController
    {
        [Route("api/avvisi")]
        public async Task<IEnumerable<string>> GetAvvisi()
        {
            return new string[] { "Avviso 1", "Avviso 2", "Avviso 3", "Avviso 4" };
        }

        [Route("api/avvisi/{id}")]
        public async Task<string> GetAvviso(int ID)
        {
            return $"Avviso con ID {ID}!";
        }

        [Route("api/segnalazione")]
        public async Task PostSegnalazione()
        {

        }

        [Route("api/richiesta")]
        public async Task PostRichiesta()
        {

        }

        [Route("api/requests")]
        public async Task<IEnumerable<string>> GetRichieste()
        {
            return null;
        }

        [Route("api/map-objects")]
        public async Task<IEnumerable<string>> GetOggettiMappa()
        {
            return null;
        }

        [Route("api/GPS")]
        public async Task PostGPS()
        {

        }
    }
}
