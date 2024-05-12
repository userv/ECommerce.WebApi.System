using ECommerce.WebApi.System.Data;
using ECommerce.WebApi.System.Models.Categories;
using ECommerce.WebApi.System.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Microsoft.CodeAnalysis.FlowAnalysis;

namespace ECommerce.WebApi.System
{
    public class SeedData
    {
        private const string DefaultAdminPassword = "Rs123456#";
        

        private static readonly Dictionary<string, IdentityRole<int>> Roles = new Dictionary<string, IdentityRole<int>>()
        {
            { "Admin", new IdentityRole<int>("Admin")},
            { "Poweruser", new IdentityRole<int>("Poweruser")},
            { "User", new IdentityRole <int>("User")}
        };



        public static async void Seed(ECommerceDbContext db, UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager)
        {


            await db.Database.MigrateAsync();
            if (await db.Categories.AnyAsync() == false)
            {
                foreach (var category in GetCategories())
                {
                    await db.Categories.AddAsync(category);
                }
                await db.SaveChangesAsync();
            }

            foreach (var identityRole in Roles)
            {
                var exists = await roleManager.RoleExistsAsync(identityRole.Key);

                if (!exists)
                {
                   await roleManager.CreateAsync(identityRole.Value);
                }
            }

            var adminUser = new User
            {
                Email = "admin@admin.bg",
                FirstName = "Superuser",
                LastName = "root",
                Address = "Sofia"
            };


            var admin = await userManager.FindByEmailAsync(adminUser.Email);
            if (admin == null)
            {

                await userManager.CreateAsync(adminUser, DefaultAdminPassword);
                await userManager.AddToRoleAsync(adminUser, Roles["Admin"].Name);
            }



        }

        private static IEnumerable<Category> GetCategories()
        {
            return new List<Category>
            {
                new Category
                {

                    Name = "Electronics",
                    Description = "Electronic products"
                },
                new Category
                {

                    Name = "Clothes",
                    Description = "Clothes products"
                },
                new Category
                {

                    Name = "Shoes",
                    Description = "Shoes products"
                },
                new Category
                {

                    Name = "Furniture",
                    Description = "Furniture products"
                },
                new Category
                {

                    Name = "Books",
                    Description = "Books products"
                },
                new Category
                {

                    Name = "Food",
                    Description = "Food products"
                },
                new Category
                {

                    Name = "Toys",
                    Description = "Toys products"
                },
                new Category
                {

                    Name = "Tools",
                    Description = "Tools products"
                },
                new Category
                {

                    Name = "Sports",
                    Description = "Sports products"
                },
                new Category
                {

                    Name = "Health",
                    Description = "Health products"
                },
                new Category
                {

                    Name = "Beauty",
                    Description = "Beauty products"
                },
                new Category
                {

                    Name = "Jewelry",
                    Description = "Jewelry products"
                },
                new Category
                {

                    Name = "Games",
                    Description = "Games products"
                },
                new Category
                {

                    Name = "Movies",
                    Description = "Movies products"
                },
                new Category
                {

                    Name = "Music",
                    Description = "Music products"
                },

            };

        }
    }
}
