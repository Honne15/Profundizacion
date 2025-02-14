using System.Text.Json.Serialization;

namespace AppProducts.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public ProductDetail? ProductDetail { get; set; }
    }
}