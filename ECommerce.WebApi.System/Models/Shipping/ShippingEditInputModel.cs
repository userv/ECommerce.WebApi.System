namespace ECommerce.WebApi.System.Models.Shipping
{
    public class ShippingEditInputModel
    {
        public int Id { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public ShippingMethod ShippingMethod { get; set; } 
        public ShippingStatus ShippingStatus { get; set; } 
        
    }
}
