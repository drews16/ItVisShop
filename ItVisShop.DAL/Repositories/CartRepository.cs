using ItVisShop.DAL.Interfaces;
using ItVisShop.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItVisShop.DAL.Repositories 
{
    public class CartRepository : IBaseRepository<Cart>
    {
        private readonly ApplicationContext _db;
        
        public CartRepository(ApplicationContext db)
        {
            _db = db;
        }

        // Создание корзины.
        public async Task<bool> Create(Cart entity)
        {
            await _db.Carts.AddAsync(entity);
            await _db.SaveChangesAsync();

            return true;
        }
        
        public async Task<bool> Delete(Cart entity)
        {
            _db.Carts.Remove(entity);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<Cart> Get(int id)
        {
            return await _db.Carts.FirstOrDefaultAsync(c => c.CartId == id);
        }

        public async Task<bool> Update(Cart entity)
        {
            _db.Carts.Update(entity);
            await _db.SaveChangesAsync();

            return true;
        }

        public IQueryable<Cart> GetAll()
        {
            return _db.Carts
                .Include(c => c.Products);
        }

        public Task<Cart> Update()
        {
            throw new NotImplementedException();
        }
    }
}
