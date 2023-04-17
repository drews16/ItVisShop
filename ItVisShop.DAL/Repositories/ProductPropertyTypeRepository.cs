using ItVisShop.DAL.Interfaces;
using ItVisShop.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace ItVisShop.DAL.Repositories
{
    public class ProductPropertyTypeRepository : IProductPropertyTypeRepository
    {
        private readonly ApplicationContext _db;

        public ProductPropertyTypeRepository(ApplicationContext db)
        {
            _db = db;
        }

        public Task<bool> Create(ProductPropertyType entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CreateAll(List<ProductPropertyType> entities)
        {
            await _db.AddRangeAsync(entities);
            await _db.SaveChangesAsync();

            return true;
        }

        public Task<bool> Delete(ProductPropertyType entity)
        {
            throw new NotImplementedException();
        }

        public Task<ProductPropertyType> Get(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ProductPropertyType> GetAll()
        {
            return _db.ProductPropertyTypes
                .Include(p => p.ProductType);
        }

        public Task<bool> Update(ProductPropertyType entity)
        {
            throw new NotImplementedException();
        }
    }
}
