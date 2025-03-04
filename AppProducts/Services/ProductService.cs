using AppProducts.Dtos;
using AppProducts.Models;
using AppProducts.Repositories;

namespace AppProducts.Services
{
    public class ProductService : IProductService
    {
        public readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> Search(string? criterios)
        {
            var products = await _productRepository.GetProducts();

            if (!string.IsNullOrWhiteSpace(criterios))
            {
                products = products.Where(p =>
                p.Name.Contains(criterios, StringComparison.OrdinalIgnoreCase) ||
                p.Price.ToString().Contains(criterios, StringComparison.OrdinalIgnoreCase)
                // p.Category.Name.Contains(criterios, StringComparison.OrdinalIgnoreCase) ||
                // p.ProductDetail.Description.Contains(criterios, StringComparison.OrdinalIgnoreCase) ||
                // p.ProductDetail.Stock.ToString().Contains(criterios, StringComparison.OrdinalIgnoreCase) ||
                // p.ProductDetail.Weight.ToString().Contains(criterios, StringComparison.OrdinalIgnoreCase) ||
                // p.ProductDetail.Dimensions.Contains(criterios, StringComparison.OrdinalIgnoreCase)
                );
            }
            return products;
        }


        public async Task<(IEnumerable<Product> items, int totalItems, int totalPages)> GetAllProductsAsync(int page, int size) => await _productRepository.GetAllAsync(page, size);

        public async Task<Product?> GetByIdAsync(int id) => await _productRepository.GetByIdAsync(id);

        public async Task AddProductAsync(ProductDto productDto)
        {
            var product = new Product
            {
                Name = productDto.Name,
                Price = productDto.Price,
                CategoryId = productDto.CategoryId,
                ProductDetail = productDto.ProductDetail != null ? new ProductDetail
                {
                    Description = productDto.ProductDetail.Description,
                    Stock = productDto.ProductDetail.Stock,
                    Weight = productDto.ProductDetail.Weight,
                    Dimensions = productDto.ProductDetail.Dimensions
                } : null
            };
            await _productRepository.AddAsync(product);
        }

        public async Task UpdateProductAsync(int id, ProductDto productDto)
        {
            var product = new Product
            {
                Name = productDto.Name,
                Price = productDto.Price,
                CategoryId = productDto.CategoryId,
                ProductDetail = new ProductDetail
                {
                    Description = productDto.ProductDetail.Description,
                    Stock = productDto.ProductDetail.Stock,
                    Weight = productDto.ProductDetail.Weight,
                    Dimensions = productDto.ProductDetail.Dimensions
                }
            };
            await _productRepository.UpdateAsync(id, product);
        }

        public async Task DeleteProductAsync(int id) => await _productRepository.DeleteAsync(id);
    }
}
