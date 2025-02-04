using AppProducts.Dtos;
using AppProducts.Models;
using AppProducts.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppProducts.Controllers
{
    [ApiController]
    [Route("/api/productDetail")]
    public class ProductDetailController : ControllerBase
    {
        private readonly IProductDetailService _productDetailService;
        public ProductDetailController(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productsDetails = await _productDetailService.GetAllProductsDetailsAsync();
            return Ok(productsDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDetailDto productDetailDto)
        {
            await _productDetailService.AddProductDetailAsync(productDetailDto);
            return CreatedAtAction(nameof(GetAll), new { id = productDetailDto.Id }, productDetailDto);
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetByProductId(int productId)
        {
            var productDetail = await _productDetailService.GetByProductIdAsync(productId);
            if (productDetail == null)
            {
                return NotFound();
            }
            return Ok(productDetail);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductDetailDto productDetailDto)
        {
            await _productDetailService.UpdateProductDetailAsync(productDetailDto);
            return Ok(productDetailDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, ProductDetailDto productDetailDto)
        {
            await _productDetailService.DeleteProductDetailAsync(id, productDetailDto);
            return Ok();
        }
    }
}