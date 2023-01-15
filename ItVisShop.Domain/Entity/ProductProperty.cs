using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
namespace ItVisShop.Domain.Entity
{
    public class ProductProperty
    {
        public int ProductId { get; set; }
        public string PropertyName { get; set; } = null!;
        public string DisplayName { get; set; } = null!;
        public string Value { get; set; } = null!;
        public string? EngUnit { get; set; }
    }
}
