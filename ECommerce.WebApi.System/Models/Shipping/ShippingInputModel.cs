namespace ECommerce.WebApi.System.Models.Shipping
{
    public class ShippingInputModel
    {
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public ShippingMethod ShippingMethod { get; set; } = ShippingMethod.Standard; // e.g., Standard, Express
        public ShippingStatus Status { get; set; } = ShippingStatus.Pending;  // e.g., Pending, Shipped, Delivered
        public int OrderId { get; set; } // Reference to the Order
    }
}
