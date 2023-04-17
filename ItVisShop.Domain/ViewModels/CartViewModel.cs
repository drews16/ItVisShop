using ItVisShop.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItVisShop.Domain.ViewModels
{
    public class CartViewModel
    {
        public decimal TotalPrice { get; set; }
        public int UserId { get; set; }
        public List<ProductCart> Products { get; set; } 
        public int ProductCount { get; set; }
    }
}
