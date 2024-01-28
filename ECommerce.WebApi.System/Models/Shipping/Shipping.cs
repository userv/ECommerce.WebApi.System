using ECommerce.WebApi.System.Models.Orders;

namespace ECommerce.WebApi.System.Models.Shipping
{
    public class Shipping: BaseModel<int>
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string ShippingMethod { get; set; } // e.g., Standard, Express
        public string TrackingNumber { get; set; }
        public string Status { get; set; } // e.g., Pending, Shipped, Delivered

        public int OrderId { get; set; } // Reference to the Order
        // Navigation property
        public virtual Order Order { get; set; }
    }
}
