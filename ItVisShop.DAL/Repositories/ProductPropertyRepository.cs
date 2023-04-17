using ItVisShop.DAL.Interfaces;
using ItVisShop.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace ItVisShop.DAL.Repositories
{
    public class ProductPropertyRepository : IProductPropertyRepository
    {
        private readonly ApplicationContext _db;

        public ProductPropertyRepository(ApplicationContext db)
        {
            _db = db;
        }

        public Task<bool> Create(ProductProperty entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CreateAll(List<ProductProperty> entities)
        {
            await _db.ProductProperties.AddRangeAsync(entities);
            await _db.SaveChangesAsync();

            return true;
        }

        public Task<bool> Delete(ProductProperty entity)
        {
            throw new NotImplementedException();
        }

        public Task<ProductProperty> Get(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ProductProperty> GetAll()
        {
            return _db.ProductProperties
                .Include(p => p.ProductPropertyType);
        }

        public Task<bool> Update(ProductProperty entity)
        {
            throw new NotImplementedException();
        }
    }
}
