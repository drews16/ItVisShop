using ItVisShop.DAL.Interfaces;
using ItVisShop.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace ItVisShop.DAL.Repositories
{
    public class ProductTypeRepository : IBaseRepository<ProductType>
    {
        private readonly ApplicationContext _db;

        public ProductTypeRepository(ApplicationContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(ProductType entity)
        {
            await _db.ProductTypes.AddAsync(entity);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(ProductType entity)
        {
            _db.ProductTypes.Remove(entity);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<ProductType> Get(int id)
        {
            return await _db.ProductTypes.FirstOrDefaultAsync(p => p.ProductTypeId == id);
        }

        public IQueryable<ProductType> GetAll()
        {
            return _db.ProductTypes;
        }

        public Task<bool> Update(ProductType entity)
        {
            throw new NotImplementedException();
        }
    }
}
