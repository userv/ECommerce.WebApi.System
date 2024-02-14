using ECommerce.WebApi.System.Models.Products;
using ECommerce.WebApi.System.Services.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace ECommerce.WebApi.System.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class ProductsController : ApiController
    {
        private readonly IProductService productService;


        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            var products = await this.productService.GetAllProducts();
            if (products == null)
            {
                return this.NotFound();
            }

            return this.Ok(products);
        }


        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetProductById(int id)
        {
            var product = await this.productService.GetProductById(id);
            if (product == null)
            {
                return this.NotFound();
            }
            return this.Ok(product);
        }

        // POST api/<ProductsController>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> CreateProduct([FromBody] ProductInputModel productInput)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var product = await this.productService.CreateProduct(productInput);
            if (product == null)
            {
                return this.BadRequest();
            }

            return this.CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);

        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult> EditProductById(int id, [FromBody] ProductInputModel productInput)
        {
            // Code logic for editing the product
            if (!ModelState.IsValid)
            {
                this.BadRequest();
            }
            var product = await this.productService.EditProductById(id, productInput);

            return this.Ok(product);

        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteProductById(int id)
        {
            // Code logic for deleting the product
            var product = await this.productService.DeleteProductById(id);
            if (product == null)
            {
                return this.NotFound();
            }
            return this.Ok(product);

        }
    }
}
