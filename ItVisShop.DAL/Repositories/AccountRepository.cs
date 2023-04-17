using ItVisShop.DAL.Interfaces;
using ItVisShop.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace ItVisShop.DAL.Repositories
{
    public class AccountRepository : IBaseRepository<User>
    {
        private readonly ApplicationContext _db;

        public AccountRepository(ApplicationContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(User entity)
        {
            await _db.Users.AddAsync(entity);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(User entity)
        {
            _db.Remove(entity);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<User> Get(int id)
        {
            return await _db.Users.FirstOrDefaultAsync(u => u.UserId == id); 
        }

        public IQueryable<User> GetAll()
        {
            return _db.Users
                .Include(u => u.Cart)
                .Include(u => u.Profile)
                    .ThenInclude(u => u.Reviews);
        }

        public Task<bool> Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
