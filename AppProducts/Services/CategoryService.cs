using AppProducts.Dtos;
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

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync() => await _categoryRepository.GetAllAsync();
        
        public async Task<CategoryDto?> GetByIdAsync(int id) => await _categoryRepository.GetByIdAsync(id);

        public async Task AddCategoryAsync(CategoryDto categoryDto) => await _categoryRepository.AddAsync(categoryDto);
       
       public async Task UpdateCategoryAsync(int id, CategoryDto categoryDto) => await _categoryRepository.UpdateAsync(id, categoryDto);

       public async Task DeleteCategoryAsync(int id) => await _categoryRepository.DeleteAsync(id);

    }
}