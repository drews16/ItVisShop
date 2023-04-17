namespace ItVisShop.Domain.Entity
{
    public class ProductCart
    {
        public int ProductCartId { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
    }
}
