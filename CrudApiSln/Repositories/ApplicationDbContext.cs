using CrudApiSln.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudApiSln.Repositories
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasKey(am => new
            {
                am.Id
            });
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder modelBuilder)
        {
            base.OnConfiguring(modelBuilder);
            //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SchoolDb;Trusted_Connection=True;");

        }
    }
}
