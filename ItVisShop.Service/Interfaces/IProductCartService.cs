using ItVisShop.Domain.Entity;
using ItVisShop.Domain.Response;
using ItVisShop.Domain.ViewModels;

namespace ItVisShop.Service.Interfaces
{
    public interface IProductCartService
    {
        Task<IBaseResponse<ProductCart>> AddInCart(ProductCartViewModel model);
        Task<IBaseResponse<ProductCart>> RemoveFromCart(int productCartId);
        Task<IBaseResponse<ProductCart>> RemoveAll(string userName);
        Task<IBaseResponse<bool>> Update(ProductCart entity);
    }
}
