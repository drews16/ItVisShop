using ItVisShop.Domain.Entity;
using ItVisShop.Domain.ViewModels;
using ItVisShop.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ItVisShop.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IProductCartService _productCartService;

        public CartController(ICartService cartService, IProductCartService productCartService)
        {
            _cartService = cartService;
            _productCartService = productCartService;
        }

        [HttpGet]
        public async Task<IActionResult> Cart()
        {            
            var response = await _cartService.GetItems(User.Identity.Name);

            if (response.StatusCode == Domain.Enum.StatusCode.Ok)
            {
                return View(response.Data);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddInCart(ProductCartViewModel model)
        {
            model.UserEmail = User.Identity.Name;

            await _productCartService.AddInCart(model);

            return RedirectToAction("Details", "Product", new { id = model.ProductId });
        }

        public void UpdateProductCart(ProductCart model)
        {
            _productCartService.Update(model);
        }

        public async Task<IActionResult> RemoveFromCart(int id)
        {
            await _productCartService.RemoveFromCart(id);

            return RedirectToAction("Cart");
        }

        [HttpGet]
        public async Task<IActionResult> RemoveAll()
        {
            await _productCartService.RemoveAll(User.Identity.Name);

            return RedirectToAction("Cart");
        }
    }
}
