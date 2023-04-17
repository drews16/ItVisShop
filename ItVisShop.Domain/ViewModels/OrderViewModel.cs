using ItVisShop.Domain.Entity;

namespace ItVisShop.Domain.ViewModels
{
    public class OrderViewModel
    {
        public List<City> Cities { get; set; }
        public List<Office> Officies { get; set; }
        public User User { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductCount { get; set; }
    }
}
