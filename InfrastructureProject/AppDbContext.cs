using EntityProject;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfrastructureProject
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = true;
        }

        public DbSet<ProfilePicture> profilePictures { get; set; }

        public DbSet<Company> companies { get; set; }

        public DbSet<Employer> employers { get; set; }

        public DbSet<JobPost> jobposts { get; set; }
        public DbSet<Education> educations { get; set; }
        public DbSet<Experience> experiences { get; set; }
        public DbSet<Skill> skills { get; set; }
        public DbSet<Interest> interests { get; set; }
        public DbSet<Project> projects { get; set; }

        public DbSet<Contribution> contributions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        
    }


}
