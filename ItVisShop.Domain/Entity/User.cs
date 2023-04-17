using ItVisShop.Domain.Enum;

namespace ItVisShop.Domain.Entity
{
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Profile Profile { get; set; }
        public Role Role { get; set; }
        public Cart Cart { get; set; }
        public List<Order> Orders { get; set; }
    }
}
