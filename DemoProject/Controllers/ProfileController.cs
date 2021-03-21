using WebProject.Models;
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
using EntityProject;
using InfrastructureProject;

namespace WebProject.Controllers
{
    public class ProfileController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _hostingEnv;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProfileController(AppDbContext context, IWebHostEnvironment hostingEnv, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _hostingEnv = hostingEnv;
            _userManager = userManager;
        }

        [Authorize]
        public ActionResult Update()
        {
            return View();
        }


        [Authorize]
        public async Task<IActionResult> Index(UpdateModel model)
        {
            if (ModelState.IsValid) {

                ApplicationUser user = await _userManager.GetUserAsync(User);
                user.Name = model.Name;
                user.PhoneNumber = model.PhoneNumber;
                user.Address = model.Address;
                user.DateofBirth = model.DateofBirth;

                var userPassword = _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, model.Password);

                if (userPassword != PasswordVerificationResult.Success)
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return RedirectToAction("Update", "Profile");
                }
                else
                {
                    await _userManager.UpdateAsync(user);
                }

                if (model.File != null)
                {
                    IFormFile file = model.File;
                    if (file.Length > 0)
                    {
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
                            var path = Path.Combine(webRootPath, entity.ProfilePicturePath);
                            if (System.IO.File.Exists(path))
                            {
                                System.IO.File.Delete(path);
                            }
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
            }
            
            return View();
        }

    }
}
