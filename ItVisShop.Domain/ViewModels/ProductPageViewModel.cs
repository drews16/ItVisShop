using ItVisShop.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItVisShop.Domain.ViewModels
{
    public class ProductPageViewModel
    {
        public string? CurrentCategory { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public PagingViewModel PageModel { get; set; } 
    }
}
