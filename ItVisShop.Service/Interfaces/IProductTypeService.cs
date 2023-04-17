using ItVisShop.Domain.Entity;
using ItVisShop.Domain.Response;

namespace ItVisShop.Service.Interfaces
{
    public interface IProductTypeService
    {
        Task<IBaseResponse<IEnumerable<ProductType>>> GetProductTypes();
        Task<IBaseResponse<ProductType>> GetProductType(int id);
    }
}
