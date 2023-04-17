using ItVisShop.DAL.Interfaces;
using ItVisShop.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace ItVisShop.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationContext _db;
        public ProductRepository(ApplicationContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(Product entity)
        {
            await _db.Products.AddAsync(entity);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(Product entity)
        {
            _db.Products.Remove(entity);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<Product> Get(int id)
        {
            return await _db.Products
                .Include(p => p.Brand)
                .Include(p => p.ProductType)
                .Include(p => p.Reviews)
                    .ThenInclude(p => p.Profile)
                .FirstOrDefaultAsync(p => p.ProductId == id);
        }

        public async Task<bool> Update(Product entity)
        {
            _db.Products.Update(entity);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<List<Product>> GetProductsByCategory(string category)
        {
            return await _db.Products
                .Include(pt => pt.ProductType)
                .Include(b => b.Brand)
                .Where(p => p.ProductType.ProductTypeName == category).ToListAsync();
        }

        public async Task<IEnumerable<ProductImage>> GetProductImages(int id)
        {
            return await _db.ProductImages.Where(i => i.ProductId == id).ToListAsync();
        }

        public async Task<IEnumerable<ProductPropertyDetails>> GetProductProperty(int id)
        {
            return await _db.ProductPropertyDetails.Where(pp => pp.ProductId == id).ToListAsync();
        }

        public IQueryable<Product> GetAll()
        {
            return _db.Products
                .Include(p => p.Brand)
                .Include(p => p.ProductType);
        }
    }
}
