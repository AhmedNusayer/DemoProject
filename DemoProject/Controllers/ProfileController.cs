﻿using WebProject.Models;
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
using System.Security.Claims;
using Microsoft.Extensions.Caching.Memory;

namespace WebProject.Controllers
{
    public class ProfileController : Controller
    {
        //private readonly AppDbContext _context;
        private IMemoryCache _cache;
        private readonly IWebHostEnvironment _hostingEnv;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRepository<ProfilePicture> _repository;
        private readonly IRepository<Education> _education;
        private readonly IRepository<Notification> _notificationRepository;

        public ProfileController(IWebHostEnvironment hostingEnv, UserManager<ApplicationUser> userManager, AppDbContext context, IMemoryCache memoryCache)
        {
            //_context = context;
            _cache = memoryCache;
            _hostingEnv = hostingEnv;
            _userManager = userManager;
            _repository = new GenericRepository<ProfilePicture>(context);
            _education = new GenericRepository<Education>(context);
            _notificationRepository = new GenericRepository<Notification>(context);

        }

        [Authorize]
        public async Task<IActionResult> Update()
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);

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
            ApplicationUser user = await _userManager.GetUserAsync(User);

            var picture = _repository.Find(item => item.UserProfile.Id == user.Id).FirstOrDefault();
            if (picture != null)
            {
                ViewBag.ProfilePicturePath = picture.ProfilePicturePath;
            }

            ViewBag.user = JsonConvert.SerializeObject(user);
            return View();
        }

        public async Task<IActionResult> ViewCV(string username)
        {
            string template = "";

            ApplicationUser user;

            if (!_cache.TryGetValue(username, out user))
            {
                user = await _userManager.FindByNameAsync(username);

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(15));

                _cache.Set(username, user, cacheEntryOptions);
            }

            if (user != null)
            {
                ViewBag.user = JsonConvert.SerializeObject(user);
                ProfilePicture picture; 

                if (!_cache.TryGetValue(user.Id, out picture))
                {
                    picture = _repository.Find(item => item.UserProfile.Id == user.Id).FirstOrDefault();

                    var cacheEntryOptions = new MemoryCacheEntryOptions()
                        .SetAbsoluteExpiration(TimeSpan.FromMinutes(15));

                    _cache.Set(user.Id, picture, cacheEntryOptions);
                }

                if (picture != null)
                {
                    ViewBag.ProfilePicturePath = picture.ProfilePicturePath;
                }
                template = user.Template;
            }

            if (template == "1")
            {
                return View("Template1");
            }
            else if (template == "2")
            {
                return View("Template2");
            }
            else if (template == "3")
            {
                return View("Template3");
            }
            else if (template == "4")
            {
                return View("Template4");
            }
            else if(template == "5")
            {
                return View("Template5");
            }
            else if (template == "6")
            {
                return View("Template6");
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
            ApplicationUser user = await _userManager.GetUserAsync(User);
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
                    ProfilePicture entity = _repository.Find(item => item.UserProfile.Id == user.Id).FirstOrDefault();
                    if (entity != null)
                    {
                        var path = Path.Combine(webRootPath, entity.ProfilePicturePath);
                        if (System.IO.File.Exists(path))
                        {
                            System.IO.File.Delete(path);
                        }
                        entity.ProfilePicturePath = "Images/" + user.Id + "_" + fileName;
                        await _repository.Update(entity);
                        picPath = entity.ProfilePicturePath;
                    }
                    else
                    {
                        ProfilePicture profilePicture = new ProfilePicture();
                        profilePicture.UserProfile = user;
                        profilePicture.ProfilePicturePath = "Images/" + user.Id + "_" + fileName;
                        //_context.profilePictures.Add(profilePicture);
                        await _repository.Add(profilePicture);
                        picPath = profilePicture.ProfilePicturePath;
                    }

                    string fullPath = Path.Combine(newPath, user.Id + "_" + fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    _cache.Remove(user.Id);
                }
            }
            return Json(picPath);
        }

        [Authorize]
        public async Task<IActionResult> UpdateProfile(UpdateModel model)
        {
            ApplicationUser user = _userManager.GetUserAsync(User).GetAwaiter().GetResult();

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

                user.Educations = model.UserDetails.Educations;  //.GetRange(0, model.UserDetails.Educations.Count)
                
                user.Experiences = model.UserDetails.Experiences;
                user.Skills = model.UserDetails.Skills;
                user.Interests = model.UserDetails.Interests;
                user.Projects = model.UserDetails.Projects;
                user.Contributions = model.UserDetails.Contributions;
                user.Template = model.UserDetails.Template;
                user.Nationality = model.UserDetails.Nationality;
                user.Profession = model.UserDetails.Profession;
                user.Gender = model.UserDetails.Gender;
                user.BloodGroup = model.UserDetails.BloodGroup;

                IdentityResult result = await _userManager.UpdateAsync(user);

                _cache.Remove(user.UserName);

            }
            return Json("/Profile/Index");
        }

        [Authorize]
        public async Task<IActionResult> Notification()
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);
            var role = await _userManager.GetRolesAsync(user);

            if (role.Any(x=> x.Contains("User")))
            {
                var notifications = _notificationRepository.Find(item => item.userto.Id == user.Id);
                ViewBag.Notifications = JsonConvert.SerializeObject(notifications);
            }
            else if(role.Any(x => x.Contains("Employer")))
            {
                var notifications = _notificationRepository.Find(item => item.post.PostAuthor.Id == user.Id);
                ViewBag.Notifications = JsonConvert.SerializeObject(notifications);
            }

            return View();
        }

        [Authorize(Roles = "Employer")]
        public async Task<IActionResult> ApplicantInfo(string userid)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(userid);
            if (user != null)
            {
                ViewBag.user = JsonConvert.SerializeObject(user);
                var picture = _repository.Find(item => item.UserProfile.Id == user.Id).FirstOrDefault();
                if (picture != null)
                {
                    ViewBag.ProfilePicturePath = picture.ProfilePicturePath;
                }
            }
            return View();
        }

        public IActionResult Chat()
        {
            return View();
        }

    }
}
