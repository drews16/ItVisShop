using System.ComponentModel.DataAnnotations;

namespace ItVisShop.Domain.Entity
{
    public class ProductPropertyType
    {
        [Key]
        public int ProductPropertyTypeId { get; set; }
        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
        public string DisplayName { get; set; }
        public string PropertyName { get; set; }
        public string? EngUnit { get; set; }
    }
}
