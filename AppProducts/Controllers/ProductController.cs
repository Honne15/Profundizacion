using AppProducts.Dtos;
using AppProducts.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppProducts.Controllers
{
    [ApiController]
    [Route("/api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string? criterios)
        {
            var products = await _productService.Search(criterios);

            if (products == null || !products.Any())
            {
                return NotFound("No se encontraron productos que coincidan con los criterios.");
            }
            
            return Ok(products);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int size = 10)
        {
            var (items, totalItems, totalPages) = await _productService.GetAllProductsAsync(page, size);
            return Ok(new { items, totalItems, totalPages });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDto productDto)
        {
            await _productService.AddProductAsync(productDto);
            return CreatedAtAction(nameof(GetAll), new { id = productDto.Id }, productDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductDto productDto)
        {
            await _productService.UpdateProductAsync(id, productDto);
            return Ok(productDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteProductAsync(id);
            return Ok();
        }
    }
}