using AppProducts.Data;
using AppProducts.Dtos;
using AppProducts.Models;
using Microsoft.EntityFrameworkCore;

namespace AppProducts.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products
                .Include(pd => pd.Category)
                .ToListAsync();
        }
        
        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products
                .Include(pd => pd.Category)
                .FirstOrDefaultAsync(pd => pd.Id == id);
        }

        public async Task AddAsync(ProductDto productDto)
        {
            var newProduct = new Product
            {
                Id = productDto.Id,
                Name = productDto.Name,
                Price = productDto.Price,
                CategoryId = productDto.CategoryId
            };

            _context.Products.Add(newProduct);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductDto productDto)
        {
            if (productDto != null)
            {
                var updateProduct = new Product
                {
                    Id = productDto.Id,
                    Name = productDto.Name,
                    Price = productDto.Price,
                    CategoryId = productDto.CategoryId
                };

                _context.Products.Update(updateProduct);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}
