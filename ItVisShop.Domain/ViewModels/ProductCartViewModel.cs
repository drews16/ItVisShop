using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItVisShop.Domain.ViewModels
{
    public class ProductCartViewModel
    {
        public int ProductCartId { get; set; }
        public string UserEmail { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
    }
}
