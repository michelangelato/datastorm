using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataStorm.Web.Data;
using Microsoft.AspNetCore.Identity;
using DataStorm.Web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DataStorm.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<Utente> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public HomeController(ApplicationDbContext db, UserManager<Utente> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;

            db.Seed(userManager, roleManager);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult OpenData()
        {

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
