using DemoProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject.Controllers
{
    public class DashboardController : Controller
    {
        private readonly UserContext _context;

        public DashboardController(UserContext context)
        {
            _context = context;

        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
