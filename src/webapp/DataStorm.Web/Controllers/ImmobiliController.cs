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
                switch(immobile.TipoAgibilita)
                {
                    case TipoAgibilita.A_Agibile:
                        result.TipoAgibilita = "A";
                        break;
                    case TipoAgibilita.B_AgibileConProntoIntervento:
                        result.TipoAgibilita = "B";
                        break;
                    case TipoAgibilita.C_ParzialmenteInagibile:
                        result.TipoAgibilita = "C";
                        break;
                    case TipoAgibilita.D_TemporaneamenteInagibile:
                        result.TipoAgibilita = "D";
                        break;
                    case TipoAgibilita.E_Inagibile:
                        result.TipoAgibilita = "E";
                        break;
                    case TipoAgibilita.F_InagibilePerRischioEsterno:
                        result.TipoAgibilita = "F";
                        break;
                }
                return PartialView("_DettaglioImmobile", result);
            }
        }




        
    }
}
