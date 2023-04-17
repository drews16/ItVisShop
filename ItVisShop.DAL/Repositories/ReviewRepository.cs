using ItVisShop.DAL.Interfaces;
using ItVisShop.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace ItVisShop.DAL.Repositories
{
    public class ReviewRepository : IBaseRepository<Review>
    {
        private readonly ApplicationContext _db;

        public ReviewRepository(ApplicationContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(Review entity)
        {
            await _db.Reviews.AddAsync(entity);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(Review entity)
        {
            _db.Reviews.Remove(entity);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<Review> Get(int id)
        {
            return await _db.Reviews.FirstOrDefaultAsync(r => r.ReviewId == id);
        }

        public IQueryable<Review> GetAll()
        {
            return _db.Reviews
                .Include(r => r.Profile)
                .Include(r => r.Product);
        }

        public Task<bool> Update(Review entity)
        {
            throw new NotImplementedException();
        }
    }
}
