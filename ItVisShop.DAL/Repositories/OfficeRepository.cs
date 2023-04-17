using ItVisShop.DAL.Interfaces;
using ItVisShop.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace ItVisShop.DAL.Repositories
{
    public class OfficeRepository : IBaseRepository<Office>
    {
        private readonly ApplicationContext _db;

        public OfficeRepository(ApplicationContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(Office entity)
        {
            await _db.Offices.AddAsync(entity);
            await _db.SaveChangesAsync();
            
            return true;
        }

        public async Task<bool> Delete(Office entity)
        {
            _db.Offices.Remove(entity);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<Office> Get(int id)
        {
            return await _db.Offices
                .Include(o => o.City)
                .FirstOrDefaultAsync(o => o.OfficeId == id);
        }

        public IQueryable<Office> GetAll()
        {
            return _db.Offices
                .Include(o => o.City);
        }

        public async Task<bool> Update(Office entity)
        {
            _db.Offices.Update(entity);
            await _db.SaveChangesAsync();

            return true;
        }

        public Task<Office> Update()
        {
            throw new NotImplementedException();
        }
    }
}
