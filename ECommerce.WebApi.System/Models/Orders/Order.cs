using ECommerce.WebApi.System.Models.Identity;
using ECommerce.WebApi.System.Models.Products;

namespace ECommerce.WebApi.System.Models.Orders
{
    public class Order : BaseModel<int>
    {

        public DateTime OrderDate { get; init; } = DateTime.UtcNow;

        // Foreign Key for User 
        public int UserId { get; set; }
        public virtual User? User { get; set; } // Navigation property for the user who placed the order

        // Collection of Order Items
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        // Payment Details
        public decimal TotalAmount { get; set; } = 0;
        public bool IsPaymentComplete { get; set; } = false;

        //// Shipping Details
        //public string ShippingAddress { get; set; } 
        //public string City { get; set; }
        //public string PostalCode { get; set; }
        //public string Country { get; set; }

        //// Order Status
        //public string Status { get; set; } // e.g., "Pending", "Shipped", "Delivered"


    }
}
