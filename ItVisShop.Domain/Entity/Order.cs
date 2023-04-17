namespace ItVisShop.Domain.Entity
{
    public class Order
    {
        public int OrderId { get; set; }
        public int UserId {get;set;}
        public User User { get; set; }
        public string Status { get; set; }
        public int OfficeId { get; set; }
        public Office Office { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime DateOfPurchase { get; set; } = DateTime.Now;
    }
}
