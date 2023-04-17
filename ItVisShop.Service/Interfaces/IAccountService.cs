using ItVisShop.Domain.Response;
using ItVisShop.Domain.ViewModels;
using ItVisShop.Domain.ViewModels.Account;
using System.Security.Claims;

namespace ItVisShop.Service.Interfaces
{
    public interface IAccountService
    {
        Task<BaseResponse<ClaimsIdentity>> Register(RegisterViewModel model);
        Task<BaseResponse<ClaimsIdentity>> Login(LoginViewModel model);
        Task<IBaseResponse<UserOrdersViewModel>> GetUserOrders(string userEmail);
    }
}
