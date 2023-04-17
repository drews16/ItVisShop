using ItVisShop.DAL.Interfaces;
using ItVisShop.Domain.Entity;

namespace ItVisShop.DAL.Repositories
{
    public class ProductImageRepository : IProductImageRepository
    {
        private readonly ApplicationContext _db;

        public ProductImageRepository(ApplicationContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(List<ProductImage> images)
        {
            await _db.ProductImages.AddRangeAsync(images);
            await _db.SaveChangesAsync();

            return true;
        }
    }
}
