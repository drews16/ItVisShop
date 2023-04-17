namespace ItVisShop.Domain.Entity
{
    public class Cart
    {
        public int CartId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } 
        public List<ProductCart> Products { get; set; }
    }
}
