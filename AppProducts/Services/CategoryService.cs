using AppProducts.Models;
using AppProducts.Repositories;

namespace AppProducts.Services
{
    public class CategoryService : ICategoryService
    {
        public readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync() => await _categoryRepository.GetAllAsync();
        
        public async Task<Category?> GetByIdAsync(int id) => await _categoryRepository.GetByIdAsync(id);

        public async Task AddCategoryAsync(Category category) => await _categoryRepository.AddAsync(category);
       
       public async Task UpdateCategoryAsync(Category category) => await _categoryRepository.UpdateAsync(category);

       public async Task DeleteCategoryAsync(int id) => await _categoryRepository.DeleteAsync(id);

    }
}