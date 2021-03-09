using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(string email, string password)
        {
            if (password == "a")
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
