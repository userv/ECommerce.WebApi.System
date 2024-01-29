using ECommerce.WebApi.System.Models.Products;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebApi.System.Services.Products
{
    public interface IProductService
    {
        Task<IEnumerable<Product>?> GetAllProducts();
        Task<Product?> GetProductById(int id);
        Task<Product?> CreateProduct([FromBody] ProductInputModel productInput);
        Task<Product?> EditProductById(int id, [FromBody] ProductInputModel productInput);
        Task<Product?> DeleteProductById(int id);
    }
}
