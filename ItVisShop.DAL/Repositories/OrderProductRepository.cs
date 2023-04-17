using ItVisShop.DAL.Interfaces;
using ItVisShop.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItVisShop.DAL.Repositories
{
    public class OrderProductRepository : IOrderProductRepository
    {
        private readonly ApplicationContext _db;

        public OrderProductRepository(ApplicationContext db)
        {
            _db = db;
        }

        public async Task<bool> AddOrderProduct(List<OrderProduct> entities)
        {
            await _db.OrderProducts.AddRangeAsync(entities);
            await _db.SaveChangesAsync();

            return true;
        }
    }
}
