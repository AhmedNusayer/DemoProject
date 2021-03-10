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
            var users = _context.Users.Where(c => c.email == email);

            if (users.Count() != 0)
            {
                User user = users.First();
                if (user !=null && user.password == password)
                {
                    return View();
                }
            }

            return View("Views/Login/Index.cshtml");
        }
    }
}
