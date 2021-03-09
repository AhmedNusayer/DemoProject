using DemoProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject.Controllers
{
    public class HomeController : Controller
    {

        private readonly UserContext _context;

        public HomeController(UserContext context)
        {
            _context = context;

        }
        public IActionResult Index(string email, string password)
        {
            User user = _context.Users.Where(c => c.email == email).First();

            if (user.password == password)
            {
                return View();
            }
            else
            {
                return View("Views/Login/Index.cshtml");
            }
            
        }
    }
}
