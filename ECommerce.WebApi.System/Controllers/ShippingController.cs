﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ECommerce.WebApi.System.Data;
using ECommerce.WebApi.System.Models.Shipping;
using ECommerce.WebApi.System.Services.Shippings;

namespace ECommerce.WebApi.System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingController : ControllerBase
    {
        private readonly ECommerceDbContext db;
        private readonly IShippingService shippingService;


        public ShippingController(ECommerceDbContext db, IShippingService shippingService)
        {
            this.db = db;
            this.shippingService = shippingService;
        }

        // GET: api/Shipping
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shipping>>> GetAllShipping()
        {
            var shipping = await this.shippingService.GetAllShipping();
            if (shipping == null)
            {
                return this.NotFound();
            }
            return this.Ok(shipping);
        }

        // GET: api/Shipping/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shipping>> GetShippingById(int id)
        {
            var shipping = await this.shippingService.GetShippingById(id);
            if (shipping == null)
            {
                return this.NotFound();
            }

            return this.Ok(shipping);
        }

        // POST: api/Shipping
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Shipping>> CreateShipping([FromBody] ShippingInputModel shippingInput)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }
            var shipping = await this.shippingService.CreateShipping(shippingInput);
            if (shipping == null)
            {
                return this.BadRequest();
            }
            return this.CreatedAtAction("GetShippingById", new { id = shipping.Id }, shipping);
        }


        // PUT: api/Shipping/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult> EditShipping([FromBody] ShippingEditInputModel shippingInput)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var shipping = await this.shippingService.EditShipping(shippingInput);
            if (shipping == null)
            {
                return NotFound();
            }

            return this.Ok(shipping);
        }


        // DELETE: api/Shipping/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteShippingById(int id)
        {
            var shipping = await this.shippingService.DeleteShippingById(id);
            if (shipping == null)
            {
                return NotFound();
            }
            return this.Ok(shipping);
        }

        // GET: api/Shipping/5/Status
        [HttpGet("{id}/Status")]
        public async Task<ActionResult<ShippingStatus>> GetShippingStatus(int id)
        {
            var shippingStatus = await this.shippingService.GetShippingStatus(id);
            if (shippingStatus == null)
            {
                return this.NotFound();
            }
            return this.Ok(shippingStatus);
        }

        // PUT: api/Shipping/5/Status
        [HttpPut("{id}/Status")]
        public async Task<ActionResult> UpdateShippingStatus(int id, [FromBody] ShippingStatus status)
        {
            var shippingStatus = await this.shippingService.UpdateShippingStatus(id, status);
            if (shippingStatus == null)
            {
                return this.NotFound();
            }
            return this.Ok(shippingStatus);
        }
    }
}
