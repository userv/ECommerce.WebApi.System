using ECommerce.WebApi.System.Models.Shipping;

namespace ECommerce.WebApi.System.Services.Shippings
{
    public interface IShippingService
    {
        Task<IEnumerable<Shipping>?> GetAllShipping();
        Task<Shipping?> GetShippingById(int id);
        Task<Shipping?> CreateShipping(ShippingInputModel shippingInput);
        Task<Shipping?> EditShipping(ShippingEditInputModel shippingInput);
        Task<Shipping?> DeleteShippingById(int id);
        Task<ShippingStatus?> GetShippingStatus(int id);
        Task<ShippingStatus?> UpdateShippingStatus(int id, ShippingStatus status);
    }
}
