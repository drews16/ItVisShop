using ItVisShop.Domain.Entity;

namespace ItVisShop.Domain.ViewModels
{
    public class UserOrdersViewModel
    {
        public User User { get; set; }
        public List<Order> ActiveOrders { get; set; }
        public List<Order> HistoryOrders { get; set; }
    }
}
