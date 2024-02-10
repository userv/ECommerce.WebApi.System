using ECommerce.WebApi.System.Models.Categories;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebApi.System.Services.Categories
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>?> GetAllCategories();
        Task<IEnumerable<Category>?> GetAllCategoriesWithProducts();
        Task<Category?> GetCategoryById(int id);
        Task<Category> CreateCategory([FromBody] CategoryInputModel categoryInput);
         Task<Category?> EditCategory(int id, [FromBody] CategoryInputModel categoryInput);
        Task<Category?> DeleteCategoryById(int id);
    }
}
