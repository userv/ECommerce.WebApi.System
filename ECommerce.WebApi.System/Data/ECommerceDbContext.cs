using System.Reflection;
using ECommerce.WebApi.System.Models.Categories;
using ECommerce.WebApi.System.Models.Identity;
using ECommerce.WebApi.System.Models.Products;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.WebApi.System.Data
{
    public class ECommerceDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {


        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Product> Products { get; set; } = default!;
        public DbSet<Category> Categories { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}




