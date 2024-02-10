using System.Data;
using ECommerce.WebApi.System.Data;
using ECommerce.WebApi.System.Models.Categories;
using ECommerce.WebApi.System.Models.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.WebApi.System.Services.Categories
{
    public class CategoryService: ICategoryService
    {
        private readonly ECommerceDbContext db;

        public CategoryService(ECommerceDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<Category>?> GetAllCategories()
        {
            return await this.db.Categories.ToListAsync();
        }

        public async Task<IEnumerable<Category>?> GetAllCategoriesWithProducts()
        {
            return await db.Categories
                .Include(c => c.Products)
                .Select(c => new Category
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    Products = c.Products.Select(p => new Product
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Description = p.Description,
                        Price = p.Price,
                        ImageUrl = p.ImageUrl,
                        CategoryId = p.CategoryId
                    }).ToList(),
                    CreatedOn = c.CreatedOn,
                    ModifiedOn = c.ModifiedOn,
                }).ToListAsync();
        }

        public async Task<Category?>GetCategoryById(int id)
        {

            return await this.db.Categories.FindAsync(id);
        }

        public async Task<Category> CreateCategory(CategoryInputModel categoryInput)
        {
            var category = new Category
            {
                Name = categoryInput.Name,
                Description = categoryInput.Description
            };
            await db.Categories.AddAsync(category);
            await db.SaveChangesAsync();
            return category;
        }

        public async Task<Category?> EditCategory(int id, CategoryInputModel categoryInput)
        {
            var category = await db.Categories.FindAsync(id);
            if (category == null)
            {
                return null;
            }

            category.Name = categoryInput.Name;
            category.Description = categoryInput.Description;
            category.ModifiedOn = DateTime.UtcNow;
            await db.SaveChangesAsync();
            return category;
        }

        public async Task<Category?> DeleteCategoryById(int id)
        {
            var category = await db.Categories.FindAsync(id);
            if (category == null)
            {
                return null;
            }
            db.Categories.Remove(category);
            await db.SaveChangesAsync();
            return category;
        }
    }
}
