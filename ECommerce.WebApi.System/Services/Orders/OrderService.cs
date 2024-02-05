using ECommerce.WebApi.System.Data;
using ECommerce.WebApi.System.Models.Orders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.WebApi.System.Services.Orders
{
    public class OrderService : IOrderService
    {
        private readonly ECommerceDbContext db;

        public OrderService(ECommerceDbContext db)
        {
            this.db = db;
        }
        public async Task<IEnumerable<Order>?> GetAllOrders()
        {

            var orders = await db.Orders.Include(order => order.OrderItems)
                .ThenInclude(orderItem => orderItem.Product)
                .ToListAsync();
            return orders;
        }

        public async Task<Order?> GetOrderById(int id)
        {

            var order = await db.Orders.FindAsync(id);

            if (order == null)
            {
                return order;
            }
            order.OrderItems = await db.OrderItems.Where(p => p.OrderId == id).ToListAsync();
            return order;
        }

        public async Task<Order?> CreateOrder(OrderInputModel orderInput)
        {
            var user = await db.Users.FindAsync(orderInput.UserId);
            if (user == null)
            {
                return null;
            }

            var order = new Order
            {
                UserId = orderInput.UserId,
                OrderItems = new List<OrderItem>(),
            };
            foreach (var item in orderInput.OrderItems)
            {
                var product = await db.Products.FindAsync(item.ProductId);
                if (product == null)
                {
                    return null;
                }
                var orderItem = new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = product.Price,
                };
                order.TotalAmount += orderItem.Price * orderItem.Quantity;
                order.OrderItems.Add(orderItem);
            }
            await db.Orders.AddAsync(order);
            await db.SaveChangesAsync();
            return order;
        }

        public async Task<Order?> EditOrder(OrderEditInputModel orderEditInput)
        {
            var order = await db.Orders.FindAsync(orderEditInput.OrderId);
            if (order == null)
            {
                return order;
            }

            if (orderEditInput.OrderItems != null)
            {
                foreach (var item in orderEditInput.OrderItems)
                {
                    var product = await db.Products.FindAsync(item.ProductId);
                    if (product == null)
                    {
                        return order;
                    }
                    var orderItem = new OrderItem
                    {
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        Price = product.Price,
                    };
                    order.TotalAmount += orderItem.Price * orderItem.Quantity;
                    order.OrderItems.Add(orderItem);
                }
            }
            order.IsPaymentComplete = orderEditInput.IsPaymentComplete;
            order.ModifiedOn = DateTime.UtcNow;
            db.Orders.Update(order);
            await db.SaveChangesAsync();
            return order;
        }

        public async Task<Order?> DeleteOrderById(int id)
        {
            var order = await db.Orders.FindAsync(id);
            if (order == null)
            {
                return null;
            }

            if (order.OrderItems != null)
                foreach (var item in order.OrderItems)
                {
                    db.OrderItems.Remove(item);
                }

            db.Orders.Remove(order);
            await db.SaveChangesAsync();
            return order;
        }
    }
}
