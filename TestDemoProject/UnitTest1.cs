using WebProject;
using WebProject.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;
using InfrastructureProject;
using InfrastructureProject.Data;
using EntityProject;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace TestDemoProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test1()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>().UseLazyLoadingProxies()
             .UseSqlServer("Server=localhost;Database=demo_project;Trusted_Connection=True;MultipleActiveResultSets=true")
             .Options;
            AppDbContext db = new AppDbContext(options);
            //var a = db.employers.Include("CompanyInfo").Include("User").FirstOrDefault();
            /* GenericRepository<Employer> repo = new GenericRepository<Employer>(db);
             var b = repo.Find(item => item.Id == 1).FirstOrDefault();
             Assert.AreEqual("Google", b.CompanyInfo.CompanyName);*/

            /*GenericRepository<Blog> repo = new GenericRepository<Blog>(db);
            //var b = new Blog();
            //b.Url = "blog 3";
            Post p = new Post();
            p.Title = "title 4";
            p.Content = "content 4";
            //b.Posts.Add(p);
            //await repo.Add(b);

            var x3 = repo.Find(item => item.BlogId == 3).FirstOrDefault();
            x3.Posts.Add(p);
            await repo.Update(x3);

            var x = await repo.GetAll();
            
            //var a = db.Posts.Where(item => item.PostId == 1).FirstOrDefault();

            Assert.AreEqual(3, x.FirstOrDefault().BlogId);*/

            //DbSet<User> users = db.Users;
            //User row = users.First();
            /*string name = row.name;

            Assert.AreEqual("a@gmail.com",row.email);
            Assert.AreEqual("Md. A", row.name);
            Assert.AreEqual(1, row.id);
            Assert.AreEqual("1234", row.password);*/
        }

        [Test]
        public void Test2()
        {
            Guid g1 = Guid.NewGuid();
            Guid g2 = Guid.NewGuid();
            Guid g3 = Guid.NewGuid();
            Guid g4 = Guid.NewGuid();
            var l1 = new List<Education>();
            l1.Add(new Education() {
                Institution = "A",
                GUID = g1
            });
            l1.Add(new Education()
            {
                Institution = "B",
                GUID=g2
            });
            l1.Add(new Education()
            {
                Institution = "C",
                GUID=g3
            });
            var l2 = new List<Education>();
            l2.Add(new Education()
            {
                Institution = "A",
                GUID=g1
            });
            l2.Add(new Education()
            {
                Institution = "B",
                GUID=g2
            });
            l2.Add(new Education()
            {
                Institution = "D",
                GUID=g4
            });
            var x = l1.Select(a => a.GUID).Except(l2.Select(a=>a.GUID));

            Assert.AreEqual(2, 2);
        }
    }
}