using Microsoft.EntityFrameworkCore;
using MVCProject.Models;

namespace MVCProject.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Audio", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Cameras", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Computers", DisplayOrder = 3 },
                new Category { Id = 4, Name = "Mobile Phones", DisplayOrder = 4 }
                );
        }
    }
}
