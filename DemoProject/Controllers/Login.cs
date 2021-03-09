using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Encodings.Web;

namespace DemoProject.Controllers
{
    public class Login : Controller
    {

        // GET: /Login/

        public IActionResult Index()
        {
            return View();
        }

    }
}
