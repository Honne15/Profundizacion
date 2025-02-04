using AppProducts.Dtos;
using AppProducts.Models;

namespace AppProducts.Repositories
{
    public interface IProductDetailRepository
    {
        Task<IEnumerable<ProductDetail>> GetAllAsync();
        Task AddAsync(ProductDetailDto productDetailDto);
        Task<ProductDetail?> GetByProductIdAsync(int productId);
        Task UpdateAsync(ProductDetailDto productDetailDto);
        Task DeleteAsync(int id, ProductDetailDto productDetailDto);
    }
}