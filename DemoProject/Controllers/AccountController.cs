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
                var user = new ApplicationUser {UserName = model.UserName, Email = model.Email, Name = model.FirstName.Trim() + " " + model.LastName.Trim(), EmailConfirmed = true };
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "User");
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
        public IActionResult Login(string ReturnUrl = null)
        {
            if (ReturnUrl != null)
            {
                ViewBag.Error = "Opps... Something went wrong. Please log in to continue";
            }
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

            if (ModelState.IsValid && VerificationCode.verificationCode == model.VerificationCode && VerificationCode.verificationCodeEmployer == model.CompanyVerificationCode)
            {
                var user = new ApplicationUser { UserName = model.UserName, Email = model.Email, Name = model.FirstName.Trim() + " " + model.LastName.Trim(), EmailConfirmed = true };
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var companyinfo = await _repository.Get(int.Parse(model.CompanyId));
                    var employer = new Employer() { User = user, CompanyInfo = companyinfo };

                    await userManager.AddToRoleAsync(user, "Employer");

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
            if (ModelState.IsValid && VerificationCode.verificationCodeCompany == model.VerificationCode)
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

        public object SendMail(string actions, string address, string companyid = null)
        {
            if(companyid != null)
            {
                var companyEmail = _repository.Get(int.Parse(companyid)).Result.CompanyEmail;
                address = address + " " + companyEmail; 
            }

            MailFactory factory = new MailFactory(actions, address);

            List<IMailInfo> mails = factory.GetMails();

            foreach (IMailInfo mailinfo in mails)
            {   
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(mailinfo.GetFromAddress());

                    mail.To.Add(mailinfo.GetToAddress());
                    mail.Subject = mailinfo.GetSubject();
                    mail.Body = mailinfo.GetBody();
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential("webproject.test123@gmail.com", "web@123!!!");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }
            }

            return null;
        }
        [HttpGet]
        public async Task<ActionResult> IsUserExists(string username)
        {
            ApplicationUser a = await userManager.FindByNameAsync(username);
            return Json(!(a == null));
        }

        [HttpGet]
        public IActionResult AccessDenied(string ReturnUrl = null)
        {
            if (ReturnUrl != null)
            {
                ViewBag.Error = "Sorry... You are not authorized to visit this page";
            }
            return View();
        }

    }
}
