using AppProducts.Dtos;
using AppProducts.Models;

namespace AppProducts.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategory();
        Task<(IEnumerable<Category> items, int totalItems, int totalPages)> GetAllAsync(int page, int size);
        Task<Category?> GetByIdAsync(int id);
        Task AddAsync(Category category);
        Task UpdateAsync(int id, Category category);
        Task DeleteAsync(int id);
    }
}