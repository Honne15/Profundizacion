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
        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            return await _context.Products
                .Include(pd => pd.Category)
                .Include(pd => pd.ProductDetail)
                .ToListAsync();
        }
        
        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            return await _context.Products
                .Include(pd => pd.Category)
                .Include(pd => pd.ProductDetail)
                .FirstOrDefaultAsync(pd => pd.Id == id);
        }

        public async Task AddAsync(ProductDto productDto)
        {
            var product = new ProductDto
            {
                Id = productDto.Id,
                Name = productDto.Name,
                Price = productDto.Price,
                CategoryId = productDto.CategoryId,
                ProductDetail = productDto.ProductDetail != null ? new ProductDetailDto
                {
                    Description = productDto.ProductDetail.Description,
                    Stock = productDto.ProductDetail.Stock,
                    Weight = productDto.ProductDetail.Weight,
                    Dimensions = productDto.ProductDetail.Dimensions
                } : null
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, ProductDto productDto)
        {
            var productExist = await _context.Products
                .Include(p => p.ProductDetail)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (productExist == null)
            {
                throw new KeyNotFoundException($"El producto con ID {id} no existe.");
            }

            productExist.Name = productDto.Name;
            productExist.Price = productDto.Price;

            if(productDto.ProductDetail != null)
            {
                productExist.ProductDetail = productExist.ProductDetail ?? new ProductDetailDto();
                productExist.ProductDetail.Description = productDto.ProductDetail.Description;
                productExist.ProductDetail.Stock = productDto.ProductDetail.Stock;
                productExist.ProductDetail.Weight = productDto.ProductDetail.Weight;
                productExist.ProductDetail.Dimensions = productDto.ProductDetail.Dimensions;

            }

            await _context.SaveChangesAsync();
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
