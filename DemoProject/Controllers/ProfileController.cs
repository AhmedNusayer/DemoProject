using DemoProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;

namespace DemoProject.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserContext _context;
        private readonly IWebHostEnvironment _hostingEnv;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProfileController(UserContext context, IWebHostEnvironment hostingEnv, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _hostingEnv = hostingEnv;
            _userManager = userManager;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

       /* [Authorize]
        public IActionResult Create()
        {
            return View();
        }*/


        [Authorize]
        public async Task<IActionResult> Create(IFormFile file)
        {
            if (file != null)
            {
                if (file.Length > 0)
                {
                    ApplicationUser user = await _userManager.GetUserAsync(User);
                    string webRootPath = _hostingEnv.WebRootPath;
                    var fileName = Path.GetFileName(file.FileName);
                    string newPath = Path.Combine(webRootPath, "Images");

                    if (!Directory.Exists(newPath))
                    {
                        Directory.CreateDirectory(newPath);
                    }

                    var entity = _context.profilePictures.Where(item => item.UserProfile.Id == user.Id).FirstOrDefault();

                    if (entity != null)
                    {
                        entity.ProfilePicturePath = "Images/" + user.Id + "_" + fileName;
                    }
                    else
                    {
                        ProfilePicture profilePicture = new ProfilePicture();
                        profilePicture.UserProfile = user;
                        profilePicture.ProfilePicturePath = "Images/" + user.Id + "_" + fileName;
                        _context.profilePictures.Add(profilePicture);
                    }

                    string fullPath = Path.Combine(newPath, user.Id + "_" + fileName);

                   /* using (StreamWriter writer = new StreamWriter("C:\\Users\\DELL\\Downloads\\case.txt"))
                    {
                        writer.WriteLine(a);
                    }*/

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    _context.SaveChanges();

                }
            }
            return View();
        }

    }
}
