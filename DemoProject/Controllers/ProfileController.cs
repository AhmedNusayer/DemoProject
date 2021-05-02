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
using InfrastructureProject.Data;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace WebProject.Controllers
{
    public class ProfileController : Controller
    {
        //private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _hostingEnv;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRepository<ProfilePicture> _repository;

        public ProfileController(IWebHostEnvironment hostingEnv, UserManager<ApplicationUser> userManager, AppDbContext context)
        {
            //_context = context;
            _hostingEnv = hostingEnv;
            _userManager = userManager;
            _repository = new GenericRepository<ProfilePicture>(context);
        }

        [Authorize]
        public async Task<IActionResult> Update()
        {
            ApplicationUser user2 = await _userManager.GetUserAsync(User);
            var user = await _userManager.Users.Include("Educations")
                .Include("Experiences")
                .Include("Skills")
                .Include("Interests")
                .Include("Projects")
                .Include("Contributions").SingleOrDefaultAsync(x => x.Id == user2.Id);
            var picture = _repository.Find(item => item.UserProfile.Id == user.Id).FirstOrDefault();
            if (picture != null)
            {
                ViewBag.ProfilePicturePath = picture.ProfilePicturePath;
            }

            ViewBag.user = JsonConvert.SerializeObject(user);
            return View();
        }


        [Authorize]
        public async Task<IActionResult> Index(UpdateModel model)
        {
            ApplicationUser user2 = await _userManager.GetUserAsync(User);
            var user = await _userManager.Users.Include("Educations")
                .Include("Experiences")
                .Include("Skills")
                .Include("Interests")
                .Include("Projects")
                .Include("Contributions").SingleOrDefaultAsync(x => x.Id == user2.Id);

            var picture = _repository.Find(item => item.UserProfile.Id == user.Id).FirstOrDefault();
            if (picture != null)
            {
                ViewBag.ProfilePicturePath = picture.ProfilePicturePath;
            }

            ViewBag.user = user;
            return View();
        }

        public async Task<IActionResult> ViewCV(string userid)
        {
            int template = 0;
            var user = await _userManager.Users.Include("Educations")
                .Include("Experiences")
                .Include("Skills")
                .Include("Interests")
                .Include("Projects")
                .Include("Contributions").SingleOrDefaultAsync(x => x.Id == userid);

            if (user != null)
            {
                ViewBag.user = JsonConvert.SerializeObject(user);
                var picture = _repository.Find(item => item.UserProfile.Id == user.Id).FirstOrDefault();
                if (picture != null)
                {
                    ViewBag.ProfilePicturePath = picture.ProfilePicturePath;
                }
                template = 4;
            }

            if (template == 1)
            {
                return View("Template1");
            }
            else if (template == 2)
            {
                return View("Template2");
            }
            else if (template == 3)
            {
                return View("Template3");
            }
            else if (template == 4)
            {
                return View("Template4");
            }
            else
            {
                return View();
            }
        }

        [Authorize]
        public async Task<ActionResult> AddPicture(IFormFile file)
        {
            var picPath = "";
            ApplicationUser user3 = await _userManager.GetUserAsync(User);
            if (file != null)
            {
                if (file.Length > 0)
                {
                    string webRootPath = _hostingEnv.WebRootPath;
                    var fileName = Path.GetFileName(file.FileName);
                    string newPath = Path.Combine(webRootPath, "Images");

                    if (!Directory.Exists(newPath))
                    {
                        Directory.CreateDirectory(newPath);
                    }

                    //var entity = _context.profilePictures.Where(item => item.UserProfile.Id == user.Id).FirstOrDefault();
                    ProfilePicture entity = _repository.Find(item => item.UserProfile.Id == user3.Id).FirstOrDefault();
                    if (entity != null)
                    {
                        var path = Path.Combine(webRootPath, entity.ProfilePicturePath);
                        if (System.IO.File.Exists(path))
                        {
                            System.IO.File.Delete(path);
                        }
                        entity.ProfilePicturePath = "Images/" + user3.Id + "_" + fileName;
                        await _repository.Update(entity);
                        picPath = entity.ProfilePicturePath;
                    }
                    else
                    {
                        ProfilePicture profilePicture = new ProfilePicture();
                        profilePicture.UserProfile = user3;
                        profilePicture.ProfilePicturePath = "Images/" + user3.Id + "_" + fileName;
                        //_context.profilePictures.Add(profilePicture);
                        await _repository.Add(profilePicture);
                        picPath = profilePicture.ProfilePicturePath;
                    }

                    string fullPath = Path.Combine(newPath, user3.Id + "_" + fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
            }
            return Json(picPath);
        }

        [Authorize]
        public async Task<IActionResult> UpdateProfile(UpdateModel model)
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);

            if (ModelState.IsValid)
            {
                user.Name = model.UserDetails.Name;
                user.PhoneNumber = model.UserDetails.PhoneNumber;
                user.Address = model.UserDetails.Address;
                user.DateofBirth = model.UserDetails.DateofBirth;
                user.Intro = model.UserDetails.Intro;
                user.Knowledge = model.UserDetails.Knowledge;
                user.Hobby = model.UserDetails.Hobby;
                user.Website = model.UserDetails.Website;
                user.Github = model.UserDetails.Github;
                user.Linkedin = model.UserDetails.Linkedin;

                user.Educations = model.UserDetails.Educations.GetRange(0, model.UserDetails.Educations.Count);
                
                user.Experiences = model.UserDetails.Experiences;
                user.Skills = model.UserDetails.Skills;
                user.Interests = model.UserDetails.Interests;
                user.Projects = model.UserDetails.Projects;
                user.Contributions = model.UserDetails.Contributions;

                var userPassword = _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, model.Password);

                if (userPassword != PasswordVerificationResult.Success)
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Json("/Profile/Update");
                }
                else
                {
                    await _userManager.UpdateAsync(user);
                }

                
            }
            return Json("/Profile/Index");
        }

    }
}
