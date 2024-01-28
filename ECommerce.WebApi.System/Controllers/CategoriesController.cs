using ECommerce.WebApi.System.Data;
using ECommerce.WebApi.System.Models;
using ECommerce.WebApi.System.Models.Categories;
using ECommerce.WebApi.System.Models.Products;
using ECommerce.WebApi.System.Services.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECommerce.WebApi.System.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class CategoriesController : ApiController
    {
        private readonly ECommerceDbContext db;
        private readonly ICategoryService categoryService;

        public CategoriesController(ECommerceDbContext dbContext, ICategoryService categoryService)
        {
            this.db = dbContext;
            this.categoryService = categoryService;
        }
        // GET: api/<CategoriesController>
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategoriesWithProducts()
        {
            var categories = await this.categoryService.GetAllCategoriesWithProducts();
            if (categories == null)
            {
                return this.NotFound();
            }
            return this.Ok(categories);

        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCategoryById(int id)
        {
            var category = await this.categoryService.GetCategoryById(id);
            if (category == null)
            {
                return this.NotFound();
            }
            return this.Ok(category);

        }

        // POST api/<CategoriesController>
        [HttpPost]
        public async Task<ActionResult> CreateCategory([FromBody] CategoryInputModel categoryInput)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var category = await this.categoryService.CreateCategory(categoryInput);
            if (category == null)
            {
                return this.BadRequest();
            }
           

            return this.CreatedAtAction(nameof(this.GetCategoryById), new { id = category.Id }, category);
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> EditCategory(int id, [FromBody] CategoryInputModel categoryInput)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var category = await this.categoryService.EditCategory(id, categoryInput);
            if (category == null)
            {
                return this.NotFound();
            }

            return this.Ok(category);

        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategoryById(int id)
        {
            var category = await this.categoryService.DeleteCategoryById(id);
            if (category == null)
            {
                return this.NotFound();
            }

            return this.Ok();
        }
    }
}
