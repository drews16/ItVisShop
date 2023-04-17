using System.ComponentModel.DataAnnotations;

namespace ItVisShop.Domain.Entity
{
    public class ProductImage
    {
        [Key]
        public int ImageId { get; set; }
        public int ProductId { get; set; }
        public string ImagePath { get; set; }
        public Product Product { get; set; }
    }
}
