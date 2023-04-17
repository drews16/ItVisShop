using ItVisShop.Domain.Entity;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ItVisShop.Domain.ViewModels.product
{
    public class CreateProductViewModel
    {
        public int BrandId { get; set; }
        public int ProductTypeId { get; set; }
        [Required(ErrorMessage = "Укажите модель")]
        public string Model { get; set; }
        [Required(ErrorMessage = "Укажите цену")]
        [Range(0, 1000000, ErrorMessage = "Цена должна быть в диапозоне от 0 до 1000000")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Выбирите главное фото")]
        public string MainImage { get; set; }
        [Required(ErrorMessage = "Укажите описание товара")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Выбирете фото")]
        public List<string> Images { get; set; }
        public int AvailableQuantity { get; set; }
        public List<CreatePropertyViewModel> Properties { get; set; }
    }
}
