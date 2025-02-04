using AppProducts.Data;
using AppProducts.Dtos;
using AppProducts.Models;
using Microsoft.EntityFrameworkCore;

namespace AppProducts.Repositories
{
    public class ProductDetailRepository : IProductDetailRepository
    {
        private readonly AppDbContext _context;
        public ProductDetailRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ProductDetail>> GetAllAsync()
        {
            return await _context.ProductsDetails
                .Include(pd => pd.Product)
                .ThenInclude(p => p.Category)
                .ToListAsync();
        }

        public async Task AddAsync(ProductDetailDto productDetailDto)
        {
            var newDetail = new ProductDetail
            {
                Id = productDetailDto.Id,
                ProductId = productDetailDto.ProductId,
                Description = productDetailDto.Description,
                Stock = productDetailDto.Stock,
                Weight = productDetailDto.Weight,
                Dimensions = productDetailDto.Dimensions
            };

            _context.ProductsDetails.Add(newDetail);
            await _context.SaveChangesAsync();
        }

        public async Task<ProductDetail?> GetByProductIdAsync(int productId)
        {
            return await _context.ProductsDetails
                .Include(pd => pd.Product)
                .ThenInclude(p => p.Category)
                .FirstOrDefaultAsync(pd => pd.ProductId == productId);
        }

        public async Task UpdateAsync(ProductDetailDto productDetailDto)
        {
            if (productDetailDto != null)
            {
                var updateDetail = new ProductDetail
                {
                    Id = productDetailDto.Id,
                    ProductId = productDetailDto.ProductId,
                    Description = productDetailDto.Description,
                    Stock = productDetailDto.Stock,
                    Weight = productDetailDto.Weight,
                    Dimensions = productDetailDto.Dimensions
                };

                _context.ProductsDetails.Update(updateDetail);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id, ProductDetailDto productDetailDto)
        {
            var productDetail = await _context.ProductsDetails.FindAsync(id);
            if (productDetail != null)
            {
                var updateDetail = new ProductDetail
                {
                    Id = productDetailDto.Id,
                    ProductId = productDetailDto.ProductId,
                    Description = productDetailDto.Description,
                    Stock = productDetailDto.Stock,
                    Weight = productDetailDto.Weight,
                    Dimensions = productDetailDto.Dimensions
                };

                _context.ProductsDetails.Remove(productDetail);
                await _context.SaveChangesAsync();
            }
        }
    }
}