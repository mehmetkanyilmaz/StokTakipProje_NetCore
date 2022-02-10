using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        public HomeController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
