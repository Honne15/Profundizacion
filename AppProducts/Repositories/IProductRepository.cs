using AppProducts.Dtos;

namespace AppProducts.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto?> GetByIdAsync(int id);
        Task AddAsync(ProductDto productDto);
        Task UpdateAsync(int id, ProductDto productDto);
        Task DeleteAsync(int id);
    }
}
