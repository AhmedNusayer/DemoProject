using WebProject.Models;
using InfrastructureProject;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using EntityProject;

namespace WebProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;

        public HomeController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Index()
        {

            var user =  await userManager.GetUserAsync(User);
            if (user != null)
            {
                var a = await userManager.GetRolesAsync(user);
                ViewBag.rolename = a.FirstOrDefault();
            }
            return View();
        }

    }
}
