using WebProject;
using WebProject.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;
using InfrastructureProject;
using InfrastructureProject.Data;
using EntityProject;

namespace TestDemoProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
             .UseSqlServer("Server=localhost;Database=demo_project;Trusted_Connection=True;MultipleActiveResultSets=true")
             .Options;
            AppDbContext db = new AppDbContext(options);
            //var a = db.employers.Include("CompanyInfo").Include("User").FirstOrDefault();
            GenericRepository<Employer> repo = new GenericRepository<Employer>(db);
            var b = repo.Find(item => item.Id == 1, new string[] { "CompanyInfo", "User" }).FirstOrDefault();
            Assert.AreEqual("Google", b.CompanyInfo.CompanyName);

            //DbSet<User> users = db.Users;
            //User row = users.First();
            /*string name = row.name;

            Assert.AreEqual("a@gmail.com",row.email);
            Assert.AreEqual("Md. A", row.name);
            Assert.AreEqual(1, row.id);
            Assert.AreEqual("1234", row.password);*/
        }
    }
}