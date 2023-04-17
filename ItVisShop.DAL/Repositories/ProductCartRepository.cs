using ItVisShop.DAL.Interfaces;
using ItVisShop.Domain.Entity;

namespace ItVisShop.DAL.Repositories
{
    public class ProductCartRepository : IProductCartRepository
    {
        private readonly ApplicationContext _db;

        public ProductCartRepository(ApplicationContext db)
        {
            _db = db;
        }

        // Добавление товара в корзину.
        public async Task<bool> AddInCart(ProductCart entity)
        {
            await _db.ProductsCart.AddAsync(entity);
            await _db.SaveChangesAsync();

            return true;
        }

        // Удаление всех товаров из коризины.
        public async Task<bool> RemoveAll(List<ProductCart> entities)
        {
            _db.RemoveRange(entities);
            await _db.SaveChangesAsync();

            return true;
        }

        // Удаление товар из корзины.
        public async Task<bool> RemoveFromCart(ProductCart entity)
        {
            _db.ProductsCart.Remove(entity);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateCart(ProductCart entity)
        {
            _db.ProductsCart.Update(entity);
            await _db.SaveChangesAsync();

            return true;
        }
    }
}
