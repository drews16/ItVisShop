using ItVisShop.Domain.Entity;
using ItVisShop.Domain.Response;
using ItVisShop.Domain.ViewModels;

namespace ItVisShop.Service.Interfaces
{
    public interface IProductService
    {
        // Получение всех продуктов. 
        Task<IBaseResponse<IEnumerable<Product>>> GetProducts();
        // Получение характеристик продукта.
        Task<IBaseResponse<ProductPropertyViewModel>> GetProductProperty(int id);

        // Получение продуктов по категории.
        Task<IBaseResponse<IEnumerable<Product>>> GetProductsByCategory(string category);
    }
}
