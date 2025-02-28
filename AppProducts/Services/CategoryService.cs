using AppProducts.Dtos;
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

        public async Task<IEnumerable<Category>> Search(string? criterios)
        {
            var categories = await _categoryRepository.GetCategory();

            if (!string.IsNullOrWhiteSpace(criterios))
            {
                categories = categories.Where(p =>
                p.Name.Contains(criterios, StringComparison.OrdinalIgnoreCase));
            }
            return categories;
        }

        public async Task<(IEnumerable<Category> items, int totalItems, int totalPages)> GetAllCategoriesAsync(int page, int size) => await _categoryRepository.GetAllAsync(page, size);
        
        public async Task<Category?> GetByIdAsync(int id) => await _categoryRepository.GetByIdAsync(id);

        public async Task AddCategoryAsync(CategoryDto categoryDto)
        {
            var category = new Category
            {
                Name = categoryDto.Name,
            };

            await _categoryRepository.AddAsync(category);
        }
       
       public async Task UpdateCategoryAsync(int id, CategoryDto categoryDto)
       {
           var category = new Category
           {
               Name = categoryDto.Name
           };

           await _categoryRepository.UpdateAsync(id, category);
       }

       public async Task DeleteCategoryAsync(int id) => await _categoryRepository.DeleteAsync(id);

    }
}