using WebProject.Models;
using InfrastructureProject;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using EntityProject;
using InfrastructureProject.Data;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

namespace WebProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;

        private readonly IRepository<JobPost> _jobRepository;
        private readonly IRepository<Employer> _employerRepository;
        private readonly IRepository<Company> _companyRepository;

        public AppDbContext Context { get; }

        public HomeController(UserManager<ApplicationUser> userManager, AppDbContext context)
        {
            this.userManager = userManager;
            Context = context;
            _jobRepository = new GenericRepository<JobPost>(context);
            _employerRepository = new GenericRepository<Employer>(context);
            _companyRepository = new GenericRepository<Company>(context);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Index(string searchString, string sort = null)
        {

            var user =  await userManager.GetUserAsync(User);
            if (user != null)
            {
                var a = await userManager.GetRolesAsync(user);
                ViewBag.rolename = a.FirstOrDefault();
                ViewBag.user = JsonConvert.SerializeObject(user);
            }

            var posts = await _jobRepository.GetAll();
            var orderdPost = posts.OrderByDescending(x => x.TimeofPost);
            List<JobPost> searchedPosts = null;
            var jsonString = "";
            ViewBag.sort = "Sort";
            if (sort == "newest")
            {
                orderdPost = posts.OrderByDescending(x => x.TimeofPost);
                ViewBag.sort = "Newest";
            }
            else if (sort == "no_of_post")
            {
                orderdPost = posts.OrderByDescending(x => x.NoOfPosts);
                ViewBag.sort = "Available Posts";
            }
            else if (sort == "by_salary")
            {
                orderdPost = posts.OrderBy(x => x.SalaryRangeStart);
                ViewBag.sort = "By Salary (L-H)";
            }
            else if (sort == "by_salary_des")
            {
                orderdPost = posts.OrderByDescending(x => x.SalaryRangeStart);
                ViewBag.sort = "By Salary (H-L)";
            }
            else
            {
                orderdPost = posts.OrderByDescending(x => x.TimeofPost);
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                searchedPosts = posts.Where(s => s.JobTitle.Contains(searchString, StringComparison.OrdinalIgnoreCase) 
                                           || s.JobLocation.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                                           || s.JobType.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                                           || s.CompanyInfo.CompanyName.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                                           .ToList();
            }

            if (searchedPosts == null)
            {
                jsonString = JsonConvert.SerializeObject(orderdPost);
            }
            else
            {
                jsonString = JsonConvert.SerializeObject(searchedPosts);
            }

            ViewBag.posts = jsonString;
            return View();
        }

        [Authorize(Roles ="Employer")]
        public async Task<IActionResult> PostJob(JobPostModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.GetUserAsync(User);
                var employer = _employerRepository.Find(item => item.User == user).FirstOrDefault();
                var company = employer.CompanyInfo;

                var jobpost = new JobPost()
                {
                    JobTitle = model.JobTitle,
                    JobDescription = model.JobDescription,
                    JobLocation = model.JobLocation,
                    JobType = model.JobType,
                    NoOfPosts = model.NoOfPosts,
                    SalaryRangeEnd = model.SalaryRangeEnd,
                    SalaryRangeStart = model.SalaryRangeStart,
                    TimeofPost = DateTime.Now,
                    PostAuthor = user,
                    CompanyInfo = company
                };

                await _jobRepository.Add(jobpost);
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult JobDetails(int id)
        {
            ViewBag.PostId = id;

            var post = _jobRepository.Find(x =>x.Id == id).FirstOrDefault();
            if(post != null)
            {
                string jsonString = JsonConvert.SerializeObject(post);
                ViewBag.PostDetails = jsonString;
            }
            return View();
        }
    }
}
