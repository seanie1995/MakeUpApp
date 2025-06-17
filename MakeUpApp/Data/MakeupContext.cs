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
                new ProductType { id = 1, name = "Lip Products" },
                new ProductType { id = 2, name = "Day Cream"},
                new ProductType { id = 3, name = "Blush"},
                new ProductType { id = 4, name = "Face Pallets"},
                new ProductType { id = 5, name = "Powder Base"},
                new ProductType { id = 6, name = "Random Cream"},
                new ProductType { id = 7, name = "Night Cream"},
                new ProductType { id = 8, name = "Cleansers"},
                new ProductType { id = 9, name = "Hair"},
                new ProductType { id = 10, name = "Highlighter"},
                new ProductType { id = 11, name = "Serum"},
                new ProductType { id = 12, name = "Base"}

                );
        }

    }
}
