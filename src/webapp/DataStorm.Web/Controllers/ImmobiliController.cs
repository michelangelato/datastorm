using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DataStorm.Web.Controllers
{
    public class ImmobiliController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
