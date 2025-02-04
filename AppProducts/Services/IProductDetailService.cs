using AppProducts.Dtos;
using AppProducts.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AppProducts.Services
{
    public interface IProductDetailService
    {
        Task<IEnumerable<ProductDetail>> GetAllProductsDetailsAsync();
        Task AddProductDetailAsync(ProductDetailDto productDetailDto);
        Task<ProductDetail?> GetByProductIdAsync(int productId);
        Task UpdateProductDetailAsync(ProductDetailDto productDetailDto);
        Task DeleteProductDetailAsync(int id, ProductDetailDto productDetailDto);
    }
}