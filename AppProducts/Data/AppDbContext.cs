using AppProducts.Dtos;
using Microsoft.EntityFrameworkCore;

namespace AppProducts.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }

        public DbSet<CategoryDto> Categories { get; set; }
        public DbSet<ProductDto> Products { get; set; }
        public DbSet<ProductDetailDto> ProductsDetails {  get; set; }
    }
}