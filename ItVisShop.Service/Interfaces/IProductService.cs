using ItVisShop.Domain.Entity;
using ItVisShop.Domain.Response;
using ItVisShop.Domain.ViewModels;
using ItVisShop.Domain.ViewModels.product;

namespace ItVisShop.Service.Interfaces
{
    public interface IProductService
    {
        Task<IBaseResponse<ProductPropertyViewModel>> GetProductProperty(int id);
        Task<IBaseResponse<IEnumerable<Product>>> GetProductsByCategory(string category);
        Task<IBaseResponse<IEnumerable<Product>>> GetTopProducts();
        Task<IBaseResponse<IEnumerable<Product>>> SearchProducts(string searchString);
        Task<IBaseResponse<Product>> CreateProduct(CreateProductViewModel model);
        Task<IBaseResponse<ProductViewModel>> GetProductPropertiesByProductType(int productTypeId);
    }
}
