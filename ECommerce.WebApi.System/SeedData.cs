
using ECommerce.WebApi.System.Data;
using ECommerce.WebApi.System.Models.Categories;
using ECommerce.WebApi.System.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.WebApi.System
{
    public class SeedData
    {
        private readonly ECommerceDbContext db;
        private readonly UserManager<User> userManager;
        public SeedData(ECommerceDbContext db, UserManager<User> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }
        public static void Seed(ECommerceDbContext db, UserManager<User> userManager)
        {


            db.Database.Migrate();
            if (db.Categories.Any() == false)
            {
                foreach (var category in GetCategories())
                {
                    db.Categories.Add(category);
                }
                // db.Categories.AddRange(GetCategories());
                db.SaveChanges();
            }

            if (db.Users.Any() == false)
            {
                foreach (var user in GetUsers())
                {
                 //   db.Users.Add(user);
                 var results=userManager.CreateAsync(user, user.Password).GetAwaiter().GetResult();
                }
                // db.Categories.AddRange(GetCategories());
                db.SaveChanges();
            }



        }

        public static IEnumerable<User> GetUsers()
        {
            return new List<User>
            {
                new User
                {
                    UserName = "user",
                    Email = "user@mail.bg",
                    FirstName = "User",
                    LastName = "User",
                    Address = "Sofia",
                    Password = "Rs123456#",
                    Role = "User"
                },
                new User
                {
                    UserName = "admin",
                    Email = "admin@admin.bg",
                    FirstName = "Superuser",
                    LastName = "root",
                    Address = "Sofia",
                    Password = "Rs123456#",
                    Role = "Admin"


                }
            };
        }
        public static IEnumerable<Category> GetCategories()
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
