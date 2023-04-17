namespace ItVisShop.Domain.Entity
{
    public class ProductProperty
    {
        public int ProductPropertyId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int ProductPropertyTypeId { get; set; }
        public ProductPropertyType ProductPropertyType { get; set; }
        public string Value { get; set; }
    }
}
