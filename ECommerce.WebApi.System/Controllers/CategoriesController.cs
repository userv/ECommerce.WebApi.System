using ECommerce.WebApi.System.Models.Categories;
using ECommerce.WebApi.System.Services.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebApi.System.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class CategoriesController : ApiController
    {

        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {

            this.categoryService = categoryService;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategories()
        {
            var categories = await this.categoryService.GetAllCategories();
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
