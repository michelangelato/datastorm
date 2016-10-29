﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataStorm.Web.Data;
using Microsoft.AspNetCore.Identity;
using DataStorm.Web.Models;

namespace DataStorm.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<Utente> _userManager;

        public HomeController(ApplicationDbContext db, UserManager<Utente> userManager)
        {
            _db = db;
            _userManager = userManager;

            db.Seed(userManager);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
