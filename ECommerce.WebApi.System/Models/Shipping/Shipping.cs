﻿using ECommerce.WebApi.System.Models.Orders;

namespace ECommerce.WebApi.System.Models.Shipping
{
    public class Shipping : BaseModel<int>
    {
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public string? TrackingNumber { get; init; } = Guid.NewGuid().ToString();
        public ShippingMethod ShippingMethod { get; set; } = ShippingMethod.Standard; // e.g., Standard, Express
        public ShippingStatus Status { get; set; } = ShippingStatus.Pending;  // e.g., Pending, Shipped, Delivered

        public int OrderId { get; init; } // Reference to the Order
        // Navigation property
        public virtual Order Order { get; init; } = default!;
    }
}
