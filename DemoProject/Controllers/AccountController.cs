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
using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Http;
using System.Collections.Concurrent;

namespace WebProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IRepository<Company> _repository;
        private readonly IRepository<Employer> _employerRepository;

       
        public AccountController(UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager,
                                 AppDbContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            _repository = new GenericRepository<Company>(context);
            _employerRepository = new GenericRepository<Employer>(context);
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid && VerificationCode.verificationCode == model.VerificationCode)
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

        [HttpGet]
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
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, Name = model.FirstName.Trim() + " " + model.LastName.Trim() };
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var companyinfo = await _repository.Get(int.Parse(model.CompanyName));
                    var employer = new Employer() { User = user, CompanyInfo = companyinfo };

                    await signInManager.SignInAsync(user, isPersistent: false);
                    await _employerRepository.Add(employer);

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

        public object Verify(string email)
        {
            VerificationCode.verificationCode = new Random().Next(100000).ToString();
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("webproject.test123@gmail.com");

                mail.To.Add(email);
                mail.Subject = "Verify your email for Job Portal";
                mail.Body = "<p>To finish setting up your Job Portal account, we just need to make sure " +
                    "this email address is yours. <br> To verify your email address use this verification code: </p>" +
                    " <b style='color: #2672ec; font-size: 35px'>" + VerificationCode.verificationCode + "</b>" + 
                    "<p>If you didn't request this" +
                    " code, you can safely ignore this email. Someone else might have " +
                    "typed your email address by mistake. <br> <br> Thanks, <br> The Job Portal account team";
                mail.IsBodyHtml = true;
                //mail.Attachments.Add(new Attachment("C:\\file.zip"));

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("webproject.test123@gmail.com", "web@123!!!");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
            return null;
        }
    }

    public static class VerificationCode
    {
        public static string verificationCode = "";
        
    }
}
