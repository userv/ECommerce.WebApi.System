using ECommerce.WebApi.System.Data;
using ECommerce.WebApi.System.Models.Products;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.WebApi.System.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly ECommerceDbContext db;

        public ProductService(ECommerceDbContext db)
        {
            this.db = db;
        }
        public async Task<IEnumerable<Product>?> GetAllProducts()
        {
            return await db.Products.ToListAsync();
            
        }

        public async Task<Product?> GetProductById(int id)
        {
            var product = await db.Products.FindAsync(id);
            return product ?? null;
        }

        public async Task<Product?> CreateProduct(ProductInputModel productInput)
        {

            var product = new Product
            {
                Name = productInput.Name,
                Description = productInput.Description,
                Price = productInput.Price,
                UnitsInStock = productInput.UnitsInStock,
                ImageUrl = productInput.ImageUrl,
                CategoryId = productInput.CategoryId
            };
            await db.Products.AddAsync(product);
            await db.SaveChangesAsync();
            return product;
        }

        public async Task<Product?> EditProductById(int id, ProductInputModel productInput)
        {
            var product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return null;
            }
            product.Name = productInput.Name;
            product.Description = productInput.Description;
            product.Price = productInput.Price;
            product.UnitsInStock = productInput.UnitsInStock;
            product.ImageUrl = productInput.ImageUrl;
            product.CategoryId = productInput.CategoryId;
            product.ModifiedOn = DateTime.UtcNow;
            db.Products.Update(product);
            await db.SaveChangesAsync();
            return product;
        }

        public async Task<Product?> DeleteProductById(int id)
        {
            var product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return null;
            }
            db.Products.Remove(product);
            await db.SaveChangesAsync();
            return product;
        }
    }
}
