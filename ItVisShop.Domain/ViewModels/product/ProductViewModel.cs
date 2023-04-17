using ItVisShop.Domain.Entity;

namespace ItVisShop.Domain.ViewModels.product
{
    public class ProductViewModel
    {
        public List<Brand> Brands { get; set; }
        public List<ProductPropertyType> ProductPropertyTypes { get; set; }
        public int ProductTypeId { get; set; }
    }
}
