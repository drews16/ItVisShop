using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItVisShop.Domain.Entity
{
    public class Product
    {
        public int ProductId { get; set; } 
        public int BrandId { get; set; }
        public Brand Brand { get; set; } = null!;
        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; } = null!;
        public string Model { get; set; } = null!;
        public decimal Price { get; set; }
        public string MainImage { get; set; }
        public string? Description { get; set; }
        public int AvailableQuantity { get; set; }
        public int CountPurchase { get; set; }
        public float Rating { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
    }
}
