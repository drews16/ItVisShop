using ItVisShop.DAL.Interfaces;
using ItVisShop.Domain.Entity;
using ItVisShop.Domain.ViewModels;
using ItVisShop.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ItVisShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // Получение страницы продуктов определенной категории.
        [HttpGet]
        public async Task<IActionResult> Products(string category, int page = 1)
        {
            var response = await _productService.GetProductsByCategory(category);
            
            int pageSize = 1;

            var count = response.Data.Count();
            var items = response.Data.Skip((page - 1) * pageSize).Take(pageSize);

            ProductPageViewModel pageVM = new ProductPageViewModel
            {
                CurrentCategory = category,
                Products = items,
                PageModel = new PagingViewModel(count, page, pageSize)
            };

            return View("/Views/Product/Products.cshtml", pageVM);
        }

        // Получение страницы с характеристиками продукта.
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var response = await _productService.GetProductProperty(id);

            return View("/Views/Product/Details.cshtml", response.Data);
        }
    }
}
