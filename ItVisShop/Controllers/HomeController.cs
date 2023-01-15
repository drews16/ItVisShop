using ItVisShop.Domain.Entity;
using ItVisShop.Domain.ViewModels;
using ItVisShop.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace ItVisShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        // Получение главной страницы.
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await _productService.GetProducts();

            return View(response.Data);
        }
    }
}