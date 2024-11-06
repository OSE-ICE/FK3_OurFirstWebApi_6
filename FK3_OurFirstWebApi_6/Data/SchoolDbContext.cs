using FK3_OurFirstWebApi_6.Models;
using Microsoft.EntityFrameworkCore;

namespace FK3_OurFirstWebApi_6.Data
{
    public class SchoolDbContext : DbContext
    {

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=SchoolDb_2");
        }
    }
}
