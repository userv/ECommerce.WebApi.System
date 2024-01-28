using ECommerce.WebApi.System.Models.Products;

namespace ECommerce.WebApi.System.Models.Categories
{
    public class Category : BaseModel<int>
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;

        public ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}