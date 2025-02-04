using AppProducts.Dtos;
using AppProducts.Models;
using AppProducts.Repositories;

namespace AppProducts.Services
{
    public class ProductDetailService : IProductDetailService
    {
        public readonly IProductDetailRepository _productDetailRepository;

        public ProductDetailService(IProductDetailRepository productDetailRepository)
        {
            _productDetailRepository = productDetailRepository;
        }

        public async Task<IEnumerable<ProductDetail>> GetAllProductsDetailsAsync() => await _productDetailRepository.GetAllAsync();
        public async Task AddProductDetailAsync(ProductDetailDto productDetailDto) => await _productDetailRepository.AddAsync(productDetailDto);
        public async Task<ProductDetail?> GetByProductIdAsync(int ProductId) => await _productDetailRepository.GetByProductIdAsync(ProductId);
        public async Task UpdateProductDetailAsync(ProductDetailDto productDetailDto) => await _productDetailRepository.UpdateAsync(productDetailDto);
        public async Task DeleteProductDetailAsync(int id, ProductDetailDto productDetailDto) => await _productDetailRepository.DeleteAsync(id, productDetailDto);
    }
}