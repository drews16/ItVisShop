using ItVisShop.Domain.ViewModels.product;
using ItVisShop.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ItVisShop.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductTypeService _productTypeService;

        public AdminController(IProductService productService, IProductTypeService productTypeService)
        {
            _productService = productService;
            _productTypeService = productTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> Admin()
        {
            var response = await _productTypeService.GetProductTypes();

            if(response.StatusCode == Domain.Enum.StatusCode.Ok)
            {
                return View(response.Data);
            }

            return View("Error");
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct(int productTypeId)
        {
            var response = await _productService.GetProductPropertiesByProductType(productTypeId);

            if(response.StatusCode == Domain.Enum.StatusCode.Ok)
            {
                return View(response.Data);
            }

            return View("Error");
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductViewModel product, IFormFile mainImage, List<IFormFile> images)
        {
            //if (ModelState.IsValid)
            //{
                var uploadPath = $"{Directory.GetCurrentDirectory()}/wwwroot/img";

                Directory.CreateDirectory(uploadPath);

                string mainImagePath = $"/img/{mainImage.FileName}";

                product.MainImage = mainImagePath;

                foreach (var file in images)
                {
                    string fullPath = $"{uploadPath}/{file.FileName}";

                    product.Images.Add($"/img/{file.FileName}");

                    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }

                var response = await _productService.CreateProduct(product);

                if (response.StatusCode == Domain.Enum.StatusCode.Ok)
                {
                    return RedirectToAction("CreateProduct");
                }

                ModelState.AddModelError("", response.Description);
            //}

            return RedirectToAction("CreateProduct", "Admin");
        }
    }
}
