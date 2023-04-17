using ItVisShop.Domain.ViewModels;
using ItVisShop.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ItVisShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IReviewService _reviewService;

        public ProductController(IProductService productService, IReviewService reviewService)
        {
            _productService = productService;
            _reviewService = reviewService;
		}

        [HttpGet]
        public async Task<IActionResult> Products(string category, int page = 1)
        {
            var response = await _productService.GetProductsByCategory(category);
            
            if(response.StatusCode == Domain.Enum.StatusCode.Ok)
            {
                int pageSize = 12;

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

            return View("Error");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var response = await _productService.GetProductProperty(id);

            if(response.StatusCode == Domain.Enum.StatusCode.Ok)
            {
                return View("/Views/Product/Details.cshtml", response.Data);
            }

            return RedirectToAction("Error");
        }

        public async Task<IActionResult> SearchProduct(string searchString)
        {
            var response = await _productService.SearchProducts(searchString);

            if(response.StatusCode == Domain.Enum.StatusCode.Ok)
            {
                return View(response.Data);
            }

            return View("Error");
        }

        [HttpGet]
        public async Task<IActionResult> Review(int productId)
        {
            return View(productId);
        }

        [HttpPost]
        public async Task<IActionResult> Review(CreateReviewViewModel model)
        {
			model.UserEmail = User.Identity.Name;

			if (ModelState.IsValid)
            {
                var response = await _reviewService.AddReview(model);

                if(response.StatusCode == Domain.Enum.StatusCode.Ok)
                {
                    return RedirectToAction("Details", new { id = model.ProductId });
                }

                ModelState.AddModelError("", response.Description);
			}

            return View(model);
        }
    }
}
