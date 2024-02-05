using ECommerce.WebApi.System.Models.Products;

namespace ECommerce.WebApi.System.Models.Orders
{
    public class OrderItem:BaseModel<int>
    {
        public int OrderId { get; set; }
        public virtual Order Order { get; set; } = default!;
        public int ProductId { get; set; }
        public virtual Product Product { get; set; } = default!;
        public decimal Price { get; set; } 
        public int Quantity { get; set; }

    }
}
