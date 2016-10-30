using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DataStorm.Web.Data;
using DataStorm.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using AutoMapper;
using DataStorm.Web.Models.DTO;
using System.Net.Http;
using System.Net.Http.Headers;

namespace DataStorm.Web.Controllers
{
    public class ImmobiliController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<Utente> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ImmobiliController(ApplicationDbContext db, UserManager<Utente> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;

            db.Seed(userManager, roleManager);
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Verifica()
        {
            return View();
        }
        [HttpGet]
        [Route("DettaglioImmobile")]
        public async Task<IActionResult> DettaglioImmobile(int idImmobile)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var immobile = _db.Immobili.Single(im => im.Id == idImmobile);
            if (user.Id != immobile.UtenteAppartenenza.Id)
            {
                throw new Exception("Immobile non trovato");

            }
            else
            {
                var result = Mapper.Map<ImmobileDTO>(immobile);
                var rnd = new Random();
                var rand = rnd.Next(1, 6);
                result.TipoAgibilita = ((TipoAgibilita)rand).ToString();
                return PartialView("_DettaglioImmobile", result);
            }
        }

        /*
        [HttpPost]
        public async Task<IActionResult> RichiediValutazione(string numeroDiPiani, string proprieta, string annoDiCostruzione, string costruzione, string percentualeUtilizzo, string uso, string posizione, string cateneCordoli, string comune)
        {
            await InvokeRequestResponseService(numeroDiPiani, proprieta, annoDiCostruzione, costruzione, percentualeUtilizzo, uso, posizione, cateneCordoli, comune);
        }
        */

        static async Task<string> InvokeRequestResponseService(string numeroDiPiani, string proprieta, string annoDiCostruzione, string costruzione, string percentualeUtilizzo, string uso, string posizione, string cateneCordoli, string comune)
        {
            using (var client = new HttpClient())
            {
                var scoreRequest = new
                {

                    Inputs = new Dictionary<string, StringTable>() {
                        {
                            "input1",
                            new StringTable()
                            {
                                ColumnNames = new string[] {"NumeroDiPiani", "Proprieta", "AnnoDiCostruzione", "Costruzione", "PercentualeUtilizzo", "Uso", "Posizione", "CateneCordoli", "Agibilita", "Comune"},
                                Values = new string[,] { { numeroDiPiani, proprieta, annoDiCostruzione, costruzione, percentualeUtilizzo, uso, posizione, cateneCordoli, null, comune },  }
                            }
                        },
                    },
                    GlobalParameters = new Dictionary<string, string>()
                    {
                    }
                };
                const string apiKey = "vWUGp6GZ80V4VeMoY/j1DXYpiqRB6GUZkS+mTLkAOX8ma+S8UVCSv9/7iHXkbggq+YB6ee8vEBNvLQL3P67naA=="; // Replace this with the API key for the web service
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

                client.BaseAddress = new Uri("https://ussouthcentral.services.azureml.net/workspaces/9da97d27abde423ab8df23c86c5ce635/services/0f6a6bf2c33f4471991d6c203d2b9398/execute?api-version=2.0&details=true");

                // WARNING: The 'await' statement below can result in a deadlock if you are calling this code from the UI thread of an ASP.Net application.
                // One way to address this would be to call ConfigureAwait(false) so that the execution does not attempt to resume on the original context.
                // For instance, replace code such as:
                //      result = await DoSomeTask()
                // with the following:
                //      result = await DoSomeTask().ConfigureAwait(false)


                HttpResponseMessage response = await client.PostAsJsonAsync("", scoreRequest);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    return result;
                }
                else
                {
                    throw new Exception("Richiesta non valida");
                }
            }
        }



    }
}
