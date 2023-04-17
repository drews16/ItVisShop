namespace ItVisShop.Domain.Entity
{
    public class ProductPropertyDetails
    {
        public int ProductId { get; set; }
        public string PropertyName { get; set; } = null!;
        public string DisplayName { get; set; } = null!;
        public string Value { get; set; } = null!;
        public string? EngUnit { get; set; }
    }
}
