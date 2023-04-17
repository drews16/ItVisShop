using ItVisShop.Domain.Entity;

namespace ItVisShop.DAL.Interfaces
{
    public interface IProductCartRepository
    {
        public Task<bool> AddInCart(ProductCart entity);
        public Task<bool> RemoveFromCart(ProductCart entity);
        public Task<bool> UpdateCart(ProductCart entity);
        public Task<bool> RemoveAll(List<ProductCart> entities);
    }
}
