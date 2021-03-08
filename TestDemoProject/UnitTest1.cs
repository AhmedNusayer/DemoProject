using DemoProject;
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
            Userdb db = new Userdb();
            DbSet<Users> users = db.Users;
            Users row = users.First();
            string name = row.Name;

            Assert.AreEqual("a@gmail.com",row.Email);
            Assert.AreEqual("Md. A", row.Name);
            Assert.AreEqual(1, row.Id);
            Assert.AreEqual("1234", row.Password);
        }
    }
}