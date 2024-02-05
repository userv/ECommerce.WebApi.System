namespace ECommerce.WebApi.System.Models.Orders;

public class OrderInputModel
{
    public int UserId { get; set; }
    public ICollection<OrderItemInputModel>? OrderItems { get; set; } = new List<OrderItemInputModel>();
}