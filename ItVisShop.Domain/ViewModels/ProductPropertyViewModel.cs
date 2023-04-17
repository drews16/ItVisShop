using ItVisShop.Domain.Entity;

namespace ItVisShop.Domain.ViewModels
{
    public class ProductPropertyViewModel
    {
        public Product Product { get; set; } 
        public IEnumerable<ProductPropertyDetails> ProductProperties { get; set; } = null!;
        public IEnumerable<ProductImage> ProductImages { get; set; } = null!;
    }
}
