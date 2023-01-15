using ItVisShop.DAL.Interfaces;
using ItVisShop.Domain.Entity;
using ItVisShop.Domain.Response;
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
                .Include(b => b.Brand)
                .Include(pt => pt.ProductType)
                .FirstOrDefaultAsync(p => p.ProductId == id);
        }

        // Получение товаров по категории.
        public async Task<List<Product>> GetProductsByCategory(string category)
        {
            return await _db.Products
                .Include(pt => pt.ProductType)
                .Include(b => b.Brand)
                .Where(p => p.ProductType.ProductTypeName == category).ToListAsync();
        }

        // Получение картинок товара.
        public async Task<IEnumerable<ProductImage>> GetProductImages(int id)
        {
            return await _db.ProductImages.Where(i => i.ProductId == id).ToListAsync();
        }

        // Получение характеристик товара.
        public async Task<IEnumerable<ProductProperty>> GetProductProperty(int id)
        {
            return await _db.ProductProperties.Where(pp => pp.ProductId == id).ToListAsync();
        }

        //Получение всех товаров.
        public async Task<List<Product>> Select()
        {
            return await _db.Products
                .Include(b => b.Brand)
                .Include(pt => pt.ProductType)
                .ToListAsync();
        }
    }
}
