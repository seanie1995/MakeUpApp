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

    }
}
