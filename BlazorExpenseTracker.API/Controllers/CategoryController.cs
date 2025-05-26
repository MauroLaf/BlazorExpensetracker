using BlazorExpenseTracker.Data.Repositories;
using BlazorExpenseTracker.Model;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;

namespace BlazorExpenseTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            return Ok(await _categoryRepository.GetAllCategoriesAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            return Ok(await _categoryRepository.GetCategoryDetailsAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] Category category)
        {
            
            Console.WriteLine($"DEBUG (API - Controlador): Category received: Name='{category.Name}'");

            if (category == null)
                return BadRequest();
            if (category.Name.Trim() == string.Empty)
            {
                ModelState.AddModelError("Name", "Category Name Souldn't be empty");
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _categoryRepository.InsertCategoryAsync(category);

            return Created("created",created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] Category category)
        {
            if (category == null)
                return BadRequest();
            if (category.Name.Trim() == string.Empty)
            {
                ModelState.AddModelError("Name", "Category Name Souldn't be empty");
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _categoryRepository.UpdateCategoryAsync(category);

            return NoContent(); //success
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if(id == 0) 
                return BadRequest();
            await _categoryRepository.DeleteCategoryAsync(id);
            return NoContent();//success
        }

        /*en caso de poner api rest con mvc
         * public IActionResult Index()
        {
            return View();
        }*/
    }
}
