using AppProducts.Models;
using System.Text.Json.Serialization;

namespace AppProducts.Dtos
{
    public class ProductDetailDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Stock { get; set; } = 0;
        public decimal? Weight { get; set; }
        public string? Dimensions { get; set; }
        
        [JsonIgnore]
        public ProductDto? Product { get; set; }
    }
}