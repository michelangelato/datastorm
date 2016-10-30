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
using Microsoft.EntityFrameworkCore;

namespace DataStorm.Web.Controllers
{
    public class AziendeController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<Utente> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AziendeController(ApplicationDbContext db, UserManager<Utente> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;

            db.Seed(userManager, roleManager);
        }

        public async Task<IActionResult> Index()
        {
            return View(await _db.Aziende.Include(a => a.AziendaTipoLavoro).ToListAsync());
        }
    }
}
