using DemoProject;
using DemoProject.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;

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
            var options = new DbContextOptionsBuilder<UserContext>()
             .UseSqlServer("Server=localhost;Database=demo_project;Trusted_Connection=True;MultipleActiveResultSets=true")
             .Options;
            UserContext db = new UserContext(options);
            DbSet<User> users = db.Users;
            User row = users.First();
            string name = row.name;

            Assert.AreEqual("a@gmail.com",row.email);
            Assert.AreEqual("Md. A", row.name);
            Assert.AreEqual(1, row.id);
            Assert.AreEqual("1234", row.password);
        }
    }
}