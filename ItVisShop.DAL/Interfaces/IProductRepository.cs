using ItVisShop.Domain.Entity;

namespace ItVisShop.DAL.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        // Получение характеристик товара.
        Task<IEnumerable<ProductPropertyDetails>> GetProductProperty(int id);

        // Получение картинок товара.
        Task<IEnumerable<ProductImage>> GetProductImages(int id);

        // Получение товара по категории.
        Task<List<Product>> GetProductsByCategory(string category);
    }
}
