using AppProducts.Data;
using AppProducts.Dtos;
using Microsoft.EntityFrameworkCore;

namespace AppProducts.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync() => await _context.Categories.ToListAsync();

        public async Task<CategoryDto?> GetByIdAsync(int id) => await _context.Categories.FirstOrDefaultAsync(p => p.Id == id);

        public async Task AddAsync(CategoryDto categoryDto)
        {
            _context.Categories.Add(categoryDto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, CategoryDto categoryDto)
        {
            var categoryExist = await _context.Categories
                .FirstOrDefaultAsync(p => p.Id == id);

            if (categoryExist == null)
            {
                throw new KeyNotFoundException($"La categoria con ID {id} no existe.");
            }

            categoryExist.Name = categoryDto.Name;

            await _context.SaveChangesAsync();
        }


        public async Task DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }
    }
}