using ECommerce.WebApi.System.Models.Orders;
using ECommerce.WebApi.System.Services.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebApi.System.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class OrdersController : ApiController
    {
        private readonly IOrderService orderService;

        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrders()
        {
            var orders = await this.orderService.GetAllOrders();

            if (orders == null)
            {
                return this.NotFound();
            }
            return this.Ok(orders);
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrderById(int id)
        {
            var order = await this.orderService.GetOrderById(id);
            if (order == null)
            {
                return this.NotFound();
            }
            return this.Ok(order);
        }

        // PUT: api/Orders/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult> EditOrder([FromBody] OrderEditInputModel orderEditInput)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var order = await this.orderService.EditOrder(orderEditInput);
            if (order == null)
            {
                return this.NotFound();
            }

            return this.Ok(order);
        }

        // POST: api/Orders
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Order>> CreateOrder([FromBody] OrderInputModel orderInput)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest();
            }
            var order = await this.orderService.CreateOrder(orderInput);
            if (order == null)
            {
                return this.BadRequest();
            }

            return this.CreatedAtAction("GetOrderById", new { id = order.Id }, order);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteOrderById(int id)
        {
            var order = await this.orderService.DeleteOrderById(id);
            if (order == null)
            {
                return this.NotFound();
            }

            return this.NoContent();
        }

    }
}
