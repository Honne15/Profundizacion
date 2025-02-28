using AppProducts.Dtos;
using AppProducts.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppProducts.Controllers
{
    [ApiController]
    [Route("/api/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string? criterios)
        {
            var categories = await _categoryService.Search(criterios);

            if (categories == null || !categories.Any())
            {
                return NotFound("No se encontraron categorias que coincidan con los criterios.");
            }
            
            return Ok(categories);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int size = 5)
        {
            var (items, totalItems, totalPages) = await _categoryService.GetAllCategoriesAsync(page, size);
            return Ok(new { items, totalItems, totalPages });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            await _categoryService.AddCategoryAsync(categoryDto);
            return CreatedAtAction(nameof(GetById), new { id = categoryDto.Id }, categoryDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, CategoryDto categoryDto)
        {
            await _categoryService.UpdateCategoryAsync(id, categoryDto);
            return Ok(categoryDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return Ok();
        }
    }
}