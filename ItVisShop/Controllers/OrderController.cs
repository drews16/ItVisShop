using ItVisShop.Domain.ViewModels;
using ItVisShop.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ItVisShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> Order()
        {
            var response = await _orderService.GetOrder(User.Identity.Name);

            if (response.StatusCode == Domain.Enum.StatusCode.Ok)
            {
                return View(response.Data);
            }

            return Content("Error");
        }

        [HttpPost]
        public async Task<IActionResult> Order(CreateOrderViewModel model)
        {
            model.userEmail = User.Identity.Name;

            var response = await _orderService.CreateOrder(model);

            if (response.StatusCode == Domain.Enum.StatusCode.Ok)
            {
                return RedirectToAction("UserOrders", "Account");
            }

            return RedirectToAction("Order");
        }
    }
}
