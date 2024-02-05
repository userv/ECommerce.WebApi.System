namespace ECommerce.WebApi.System.Models.Orders
{
    public class OrderEditInputModel
    {
        public int OrderId { get; set; }
        public List<OrderItemInputModel> OrderItems { get; set; } = new List<OrderItemInputModel>();
        public bool IsPaymentComplete { get; set; }

    }
}
