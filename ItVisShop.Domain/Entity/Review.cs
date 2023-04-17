namespace ItVisShop.Domain.Entity
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string ReviewText { get; set; }
        public int UserMark { get; set; }
        public DateTime DateOfCreate { get; set; } = DateTime.Now;
    }
}
