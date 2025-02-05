using AppProducts.Dtos;
using AppProducts.Models;
using AppProducts.Repositories;

namespace AppProducts.Services
{
    public class ProductService : IProductService
    {
        public readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync() => await _productRepository.GetAllAsync();
        public async Task<ProductDto?> GetByIdAsync(int id) => await _productRepository.GetByIdAsync(id);
        public async Task AddProductAsync(ProductDto productDto) => await _productRepository.AddAsync(productDto);
        public async Task UpdateProductAsync(int id, ProductDto productDto) => await _productRepository.UpdateAsync(id,productDto);
        public async Task DeleteProductAsync(int id) => await _productRepository.DeleteAsync(id);
    }
}
