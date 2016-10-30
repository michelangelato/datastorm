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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DataStorm.Web.Controllers
{
    public class SegnalazioniController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<Utente> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SegnalazioniController(ApplicationDbContext db, UserManager<Utente> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;

            db.Seed(userManager, roleManager);
        }

        [Authorize]
        public IActionResult Index()
        {
            var tipologie = Enum.GetValues(typeof(TipologiaSegnalazione)).Cast<TipologiaSegnalazione>();
            return View(tipologie.Select(t => new SelectListItem { Text = Enum.GetName(typeof(TipologiaSegnalazione), t), Value = ((int)t).ToString() }));
        }
    }
}
