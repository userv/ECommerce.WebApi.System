using ECommerce.WebApi.System.Data;
using ECommerce.WebApi.System.Models.Shipping;
using ECommerce.WebApi.System.Services.Shippings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.WebApi.System.Services.Shippings
{
    public class ShippingService : IShippingService
    {
        private readonly ECommerceDbContext db;

        public ShippingService(ECommerceDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<Shipping>?> GetAllShipping()
        {
            return await this.db.Shippings.ToListAsync();
        }

        public async Task<Shipping?> GetShippingById(int id)
        {
            return await db.Shippings.FindAsync(id);

        }

        public async Task<Shipping?> CreateShipping(ShippingInputModel shippingInput)
        {
            var shipping = new Shipping
            {
                Address = shippingInput.Address,
                City = shippingInput.City,
                PostalCode = shippingInput.PostalCode,
                Country = shippingInput.Country,
                ShippingMethod = shippingInput.ShippingMethod,
                Status = shippingInput.Status,
                //   TrackingNumber = Guid.NewGuid().ToString(),
                OrderId = shippingInput.OrderId
            };
            await this.db.Shippings.AddAsync(shipping);
            await this.db.SaveChangesAsync();
            return shipping;
        }

        public async Task<Shipping?> EditShipping(ShippingEditInputModel shippingInput)
        {
            var shipping = await db.Shippings.FindAsync(shippingInput.Id);
            if (shipping == null)
            {
                return null;
            }
            shipping.Address = shippingInput.Address;
            shipping.City = shippingInput.City;
            shipping.PostalCode = shippingInput.PostalCode;
            shipping.Country = shippingInput.Country;
            shipping.ShippingMethod = shippingInput.ShippingMethod;
            shipping.Status = shippingInput.ShippingStatus;
            shipping.ModifiedOn = DateTime.UtcNow;
            this.db.Update(shipping);
            await this.db.SaveChangesAsync();
            return shipping;
        }

        public async Task<Shipping?> DeleteShippingById(int id)
        {
            var shipping = await db.Shippings.FindAsync(id);
            if (shipping == null)
            {
                return null;
            }

            db.Shippings.Remove(shipping);
            await db.SaveChangesAsync();
            return shipping;
        }

        public async Task<ShippingStatus?> GetShippingStatus(int id)
        {
            var shipping = await this.db.Shippings.FindAsync(id);
            if (shipping == null)
            {
                return null;
            }
            return shipping.Status;
        }

        public async Task<ShippingStatus?> UpdateShippingStatus(int id, ShippingStatus status)
        {
            var shipping = await db.Shippings.FindAsync(id);
            if (shipping == null)
            {
                return null;
            }
            shipping.Status = status;
            shipping.ModifiedOn = DateTime.UtcNow;
            db.Shippings.Update(shipping);
            await db.SaveChangesAsync();
            return shipping.Status;
        }
    }
}
