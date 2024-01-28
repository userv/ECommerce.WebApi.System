using ECommerce.WebApi.System.Models.Identity;
using ECommerce.WebApi.System.Models.Products;

namespace ECommerce.WebApi.System.Models.Orders
{
    public class Order: BaseModel<int>
    {
        
        public DateTime OrderDate { get; set; }

        // Foreign Key for User 
        public string UserId { get; set; }
        public virtual User User { get; set; } // Navigation property for the user who placed the order

        // Collection of Order Items
        public virtual ICollection<Product> Products { get; set; }

        // Payment Details
        public decimal TotalAmount { get; set; }
        public bool IsPaymentComplete { get; set; }

        //// Shipping Details
        //public string ShippingAddress { get; set; } 
        //public string City { get; set; }
        //public string PostalCode { get; set; }
        //public string Country { get; set; }

        //// Order Status
        //public string Status { get; set; } // e.g., "Pending", "Shipped", "Delivered"


    }
}
