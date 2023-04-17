using ItVisShop.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ItVisShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await _productService.GetTopProducts();

            if(response.StatusCode == Domain.Enum.StatusCode.Ok)
            {
                return View(response.Data);
            }

            return View("Error");
        }
    }
}