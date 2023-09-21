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
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Audio", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Cameras", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Computers", DisplayOrder = 3 },
                new Category { Id = 4, Name = "Mobile Phones", DisplayOrder = 4 }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "iPhone 12",
                    Description = "The latest iPhone with powerful features.",
                    Brand = "Apple",
                    ModelNumber = "12",
                    Price = 900,
                    InStockQuantity = 10,
                    CategoryId = 8,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 2,
                    Title = "Samsung Galaxy S21",
                    Description = "A flagship smartphone from Samsung.",
                    Brand = "Samsung",
                    ModelNumber = "S21",
                    Price = 850,
                    InStockQuantity = 15,
                    CategoryId = 8,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 3,
                    Title = "Bose QuietComfort 35 II",
                    Description = "Noise-canceling wireless headphones.",
                    Brand = "Bose",
                    ModelNumber = "QC35 II",
                    Price = 350,
                    InStockQuantity = 8,
                    CategoryId = 1,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 4,
                    Title = "Canon EOS 80D",
                    Description = "A DSLR camera with advanced features.",
                    Brand = "Canon",
                    ModelNumber = "EOS 80D",
                    Price = 1000,
                    InStockQuantity = 12,
                    CategoryId = 2,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 5,
                    Title = "Dell XPS 13",
                    Description = "A high-performance laptop from Dell.",
                    Brand = "Dell",
                    ModelNumber = "XPS 13",
                    Price = 1300,
                    InStockQuantity = 5,
                    CategoryId = 3,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 6,
                    Title = "Lenovo ThinkPad X1 Carbon",
                    Description = "A business-class ultrabook from Lenovo.",
                    Brand = "Lenovo",
                    ModelNumber = "ThinkPad X1 Carbon",
                    Price = 1600,
                    InStockQuantity = 3,
                    CategoryId = 3,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 7,
                    Title = "Sony WH-1000XM4",
                    Description = "Wireless noise-canceling headphones.",
                    Brand = "Sony",
                    ModelNumber = "WH-1000XM4",
                    Price = 350,
                    InStockQuantity = 20,
                    CategoryId = 1,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 8,
                    Title = "Google Pixel 6",
                    Description = "A flagship smartphone from Google.",
                    Brand = "Google",
                    ModelNumber = "Pixel 6",
                    Price = 700,
                    InStockQuantity = 18,
                    CategoryId = 8,
                    ImageUrl = ""
                }
                );
        }
    }
}
