using Microsoft.EntityFrameworkCore;

namespace ItVisShop.Domain.Entity
{
    public class ProductType
    {
        public int ProductTypeId { get; set; }
        public string ProductTypeName { get; set; } = null!;
    }
}
