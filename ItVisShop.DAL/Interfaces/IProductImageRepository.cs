using ItVisShop.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItVisShop.DAL.Interfaces
{
    public interface IProductImageRepository
    {
        Task<bool> Create(List<ProductImage> images);
    }
}
