using ItVisShop.DAL.Interfaces;
using ItVisShop.Domain.Entity;
using ItVisShop.Domain.Response;
using ItVisShop.Domain.ViewModels;

namespace ItVisShop.Service.Interfaces
{
    public interface ICartService
    {        
        Task<IBaseResponse<CartViewModel>> GetItems(string userId);
        Task<IBaseRepository<Cart>> RemoveProductFromCart(int Id);
    }
}
