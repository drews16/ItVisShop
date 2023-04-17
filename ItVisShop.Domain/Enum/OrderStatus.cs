using System.ComponentModel.DataAnnotations;

namespace ItVisShop.Domain.Enum
{
    public enum OrderStatus
    {
        [Display(Name = "Оплачено")]
        Paid = 1,
        [Display(Name ="Доставляется")]
        NotDelivered = 2,
        [Display(Name = "Доставлено")]
        Delivered = 3
    }
}
