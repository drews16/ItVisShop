namespace ItVisShop.Domain.Entity
{
    public class Profile
    {
        public int ProfileId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
    }
}
