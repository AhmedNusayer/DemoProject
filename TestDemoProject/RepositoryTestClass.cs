using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityProject;
using InfrastructureProject;
using InfrastructureProject.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;


namespace TestDemoProject
{
    class RepositoryTestClass
    {
        TestClassRepository repository;
        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DbContext>()
             .UseSqlServer("Server=localhost;Database=demo_project;Trusted_Connection=True;MultipleActiveResultSets=true")
             .Options;
            TestDbContext db = new TestDbContext(options);
            repository = new TestClassRepository(db);
        }



        /*[Test]
        public async Task TestGet()
        {
          var obj = await repository.Get(1);
          Assert.AreEqual("a", obj.Name);
        }*/

        /*[Test]
        public async Task TestGetAll()
        {
            var obj1 = await repository.GetAll();
            Assert.AreEqual(4, obj1.Count);
        }*/

        /*[Test]
        public async Task TestAdd()
        {
            TestClass1 test1 = new TestClass1();
            test1.Id = 4;
            test1.Name = "d";
            var obj1 = await repository.Add(test1);
            Assert.AreEqual("d", obj1.Name);
        }*/

        /*[Test]
        public async Task TestUpdate()
        {
            *//*TestClass1 test1 = repository.Find(item => item.Id == 1).First();
            test1.Name = "aa";*//*
            TestClass1 test1 = new TestClass1();
            test1.Id = 5;
            test1.Name = "ee";
            var obj1 = await repository.Update(test1);
            Assert.AreEqual("ee", obj1.Name);
        }*/

        /*[Test]
        public async Task TestAddRange()
        {
            TestClass1 test1 = new TestClass1();
            test1.Id = 10;
            test1.Name = "f";
            TestClass1 test2 = new TestClass1();
            test2.Id = 11;
            test2.Name = "g";
            TestClass1 test3 = new TestClass1();
            test3.Id = 12;
            test3.Name = "h";

            List<TestClass1> testList = new List<TestClass1>();
            testList.Add(test1);
            testList.Add(test2);
            testList.Add(test3);

            await repository.AddRange(testList.ToArray());
            var x = await repository.GetAll();
            Assert.AreEqual(12, x.Count);
        }*/

        /*[Test]
        public async Task TestDelete()
        {
            var obj1 = await repository.Delete(1);
            Assert.AreEqual("aa", obj1.Name);
        }*/

        /*[Test]
        public async Task TestRemove()
        {
            //TestClass1 test1 = repository.Find(item => item.Id == 3).First();
            TestClass1 test1 = new TestClass1();
            test1.Id = 6;
            test1.Name = "f";
            await repository.Remove(test1);
            var x = await repository.GetAll();
            Assert.AreEqual(5, x.Count);
        }*/

        /*[Test]
        public async Task TestRemoveRange()
        {
            TestClass1 test1 = new TestClass1();
            test1.Id = 10;
            test1.Name = "f";
            TestClass1 test2 = new TestClass1();
            test2.Id = 11;
            test2.Name = "g";
            TestClass1 test3 = new TestClass1();
            test3.Id = 12;
            test3.Name = "h";

            List<TestClass1> testList = new List<TestClass1>();
            testList.Add(test1);
            testList.Add(test2);
            testList.Add(test3);

            await repository.RemoveRange(testList.ToArray());
            var x = await repository.GetAll();
            Assert.AreEqual(6, x.Count);
        }*/

    }

    class TestClass1 : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

    }

    class TestClassRepository : GenericRepository<TestClass1>
    {
        public TestClassRepository(DbContext context) : base(context)
        {
        }
    }

    class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<DbContext> options) : base(options)
        {
        }

        public DbSet<TestClass1> TestClass1 { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
