using WebProject.Models;
using EntityProject;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfrastructureProject;
using InfrastructureProject.Data;

namespace WebProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IRepository<Company> _repository;

        public AccountController(UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager,
                                 AppDbContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            _repository = new GenericRepository<Company>(context);
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                /*.Substring(0, model.Email.IndexOf("@"))*/
                var user = new ApplicationUser {UserName = model.Email, Email = model.Email, Name = model.FirstName.Trim() + " " + model.LastName.Trim() };
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index","Home");
                }
               
                
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager
                    .PasswordSignInAsync(model.Email, model.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Invalid Login Attempt");
                

            }
            else
            {
                return RedirectToAction("Update", "Profile");
            }
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> RegisterEmployer()
        {
            var company = await _repository.GetAll();
            ViewBag.data = company;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterEmployer(RegisterEmployerModel model)
        {
            var company = await _repository.GetAll();
            ViewBag.data = company;

            if (ModelState.IsValid)
            {
                /*.Substring(0, model.Email.IndexOf("@"))*/
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, Name = model.FirstName.Trim() + " " + model.LastName.Trim() };
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult RegisterCompany()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterCompany(RegisterCompanyModel model)
        {
            if (ModelState.IsValid)
            {
                Company company = new Company()
                {
                    CompanyName = model.CompanyName,
                    CompanyAddress = model.CompanyAddress,
                    CompanyEmail = model.CompanyEmail,
                    CompanyLocation = model.CompanyLocation,
                    CompanyType = model.CompanyType
                };

                await _repository.Add(company);

                return RedirectToAction("RegisterEmployer", "Account");
            }

            return View();
        }
    }
}
