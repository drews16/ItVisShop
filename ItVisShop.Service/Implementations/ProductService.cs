using ItVisShop.DAL.Interfaces;
using ItVisShop.Domain.Entity;
using ItVisShop.Domain.Enum;
using ItVisShop.Domain.Response;
using ItVisShop.Domain.ViewModels;
using ItVisShop.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItVisShop.Service.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // Получение всех продуктов.
        public async Task<IBaseResponse<IEnumerable<Product>>> GetProducts()
        {
            var baseResponse = new BaseResponse<IEnumerable<Product>>();

            try
            {
                var products = await _productRepository.Select();

                if (products.Count == 0)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = StatusCode.Ok;

                    return baseResponse;
                }

                baseResponse.Data = products;
                baseResponse.StatusCode = StatusCode.Ok;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Product>>()
                {
                    Description = $"{GetProducts} : {ex.Message}"
                };
            }
        }

        // Получение характеристик продукта. 
        public async Task<IBaseResponse<ProductPropertyViewModel>> GetProductProperty(int id)
        {
            var baseResponse = new BaseResponse<ProductPropertyViewModel>();

            try
            {
                var product = await _productRepository.Get(id);
                var productPorperties = await _productRepository.GetProductProperty(id);
                var productImages = await _productRepository.GetProductImages(id);

                var productPropertyVM = new ProductPropertyViewModel
                {
                    Product = product,
                    ProductProperties = productPorperties,
                    ProductImages = productImages
                };

                baseResponse.Data = productPropertyVM;
                baseResponse.StatusCode = StatusCode.Ok;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<ProductPropertyViewModel>()
                {
                    Description = $"{GetProductProperty} : {ex.Message}"
                };
            }
        }

        // Получение всех продуктов определенной категории.
        public async Task<IBaseResponse<IEnumerable<Product>>> GetProductsByCategory(string category)
        {
            var baseResponse = new BaseResponse<IEnumerable<Product>>();

            try
            {
                var products = await _productRepository.GetProductsByCategory(category);

                if (products.Count == 0)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = StatusCode.Ok;

                    return baseResponse;
                }

                baseResponse.Data = products;
                baseResponse.StatusCode = StatusCode.Ok;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Product>>()
                {
                    Description = $"{GetProductsByCategory} : {ex.Message}"
                };
            }
        }
    }   
}       
        
    

