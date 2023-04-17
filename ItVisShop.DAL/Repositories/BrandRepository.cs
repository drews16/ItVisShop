using ItVisShop.DAL.Interfaces;
using ItVisShop.Domain.Entity;

namespace ItVisShop.DAL.Repositories
{
    public class BrandRepository : IBaseRepository<Brand>
    {
        private readonly ApplicationContext _db;
        
        public BrandRepository(ApplicationContext db)
        {
            _db = db;
        }

        public Task<bool> Create(Brand entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Brand entity)
        {
            throw new NotImplementedException();
        }

        public Task<Brand> Get(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Brand> GetAll()
        {
            return _db.Brands;
        }

        public Task<bool> Update(Brand entity)
        {
            throw new NotImplementedException();
        }
    }
}
