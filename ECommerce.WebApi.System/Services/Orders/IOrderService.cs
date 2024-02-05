using ECommerce.WebApi.System.Models.Orders;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebApi.System.Services.Orders
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>?> GetAllOrders();
        Task<Order?> GetOrderById(int id);
        Task<Order?> CreateOrder([FromBody] OrderInputModel orderInput);
        Task<Order?> EditOrder(OrderEditInputModel orderEditInput);
        Task<Order?> DeleteOrderById(int id);
    }
}
