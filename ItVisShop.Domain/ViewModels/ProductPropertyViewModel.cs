using ItVisShop.Domain.Entity;

namespace ItVisShop.Domain.ViewModels
{
    public class ProductPropertyViewModel
    {
        public Product Product { get; set; } = null!;
        public IEnumerable<ProductProperty> ProductProperties { get; set; } = null!;
        public IEnumerable<ProductImage> ProductImages { get; set; } = null!;
    }
}
