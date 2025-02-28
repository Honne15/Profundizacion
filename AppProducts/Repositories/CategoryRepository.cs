using AppProducts.Data;
using AppProducts.Dtos;
using AppProducts.Models;
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

        public async Task<IEnumerable<Category>> GetCategory()
        {
            return await _context.Categories
                .ToListAsync();
        }

        public async Task<(IEnumerable<Category> items, int totalItems, int totalPages)> GetAllAsync(int page, int size)
        {
            var totalItems = await _context.Categories.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalItems / size);
            var categories = await _context.Categories
                .Skip((page - 1) * size)
                .Take(size)
                .ToListAsync();
            return (categories, totalItems, totalPages);
        }

        public async Task<Category?> GetByIdAsync(int id) => await _context.Categories.FirstOrDefaultAsync(p => p.Id == id);

        public async Task AddAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, Category category)
        {
            var categoryExist = await _context.Categories
                .FirstOrDefaultAsync(p => p.Id == id);

            if (categoryExist == null)
            {
                throw new KeyNotFoundException($"La categoria con ID {id} no existe.");
            }

            categoryExist.Name = category.Name;

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