using ItVisShop.Domain.Response;
using ItVisShop.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItVisShop.Service.Interfaces
{
    public interface IOrderService
    {
        Task<IBaseResponse<OrderViewModel>> GetOrder(string userEmail);
        Task<IBaseResponse<bool>> CreateOrder(CreateOrderViewModel model);
    }
}
