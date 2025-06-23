using MakeUpApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MakeUpApp.Data
{
    public class MakeupContext : IdentityDbContext<User>
    {
        public MakeupContext(DbContextOptions<MakeupContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ProductType>().HasData(
                new ProductType { Id = 1, Name= "Lip Products" },
                new ProductType { Id = 2, Name= "Day Cream"},
                new ProductType { Id = 3, Name= "Blush"},
                new ProductType { Id = 4, Name= "Face Pallets"},
                new ProductType { Id = 5, Name= "Powder Base"},
                new ProductType { Id = 6, Name= "Random Cream"},
                new ProductType { Id = 7, Name= "Night Cream"},
                new ProductType { Id = 8, Name= "Cleansers"},
                new ProductType { Id = 9, Name= "Hair"},
                new ProductType { Id = 10,Name = "Highlighter"},
                new ProductType { Id = 11,Name = "Serum"},
                new ProductType { Id = 12,Name = "Base"}

                );
        }

    }
}
