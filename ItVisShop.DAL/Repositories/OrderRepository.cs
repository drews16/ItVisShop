using ItVisShop.DAL.Interfaces;
using ItVisShop.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace ItVisShop.DAL.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationContext _db;

        public OrderRepository(ApplicationContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(Order entity)
        {
            await _db.Orders.AddAsync(entity);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(Order entity)
        {
            _db.Orders.Remove(entity);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<Order> Get(int id)
        {
            return await _db.Orders.FirstOrDefaultAsync(o => o.OrderId == id);
        }

        public IQueryable<Order> GetAll()
        {
            return _db.Orders
                .Include(o => o.User)
                .Include(o => o.Office)
                    .ThenInclude(o => o.City);
        }

        public async Task<bool> Update(Order entity)
        {
            _db.Orders.Update(entity);
            await _db.SaveChangesAsync();

            return true;
        }

        public Task<Order> Update()
        {
            throw new NotImplementedException();
        }
    }
}
