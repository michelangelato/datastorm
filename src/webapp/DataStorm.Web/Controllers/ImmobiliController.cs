using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DataStorm.Web.Data;
using DataStorm.Web.Models;
using Microsoft.AspNetCore.Identity;

namespace DataStorm.Web.Controllers
{
    public class ImmobiliController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<Utente> _userManager;

        public ImmobiliController(ApplicationDbContext db, UserManager<Utente> userManager)
        {
            _db = db;
            _userManager = userManager;

            db.Seed(userManager);
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
        
    }
}
