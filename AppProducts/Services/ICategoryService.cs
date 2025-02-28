using AppProducts.Dtos;
using AppProducts.Models;

namespace AppProducts.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> Search(string? criterios);
        Task<(IEnumerable<Category> items, int totalItems, int totalPages)> GetAllCategoriesAsync(int page, int size);
        Task<Category?> GetByIdAsync(int id);
        Task AddCategoryAsync(CategoryDto categoryDto);
        Task UpdateCategoryAsync(int id, CategoryDto categoryDto);
        Task DeleteCategoryAsync(int id);
    }
}