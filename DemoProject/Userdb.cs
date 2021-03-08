using Microsoft.EntityFrameworkCore;

namespace DemoProject
{
    public class Userdb: DbContext
    {
        public Userdb()
        {
          
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Server=localhost;Database=demo_project;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public DbSet<Users> Users { get; set; }

    }

}
