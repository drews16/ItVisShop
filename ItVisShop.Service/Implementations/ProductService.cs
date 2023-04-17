using ItVisShop.DAL.Interfaces;
using ItVisShop.Domain.Entity;
using ItVisShop.Domain.Enum;
using ItVisShop.Domain.Response;
using ItVisShop.Domain.ViewModels;
using ItVisShop.Domain.ViewModels.product;
using ItVisShop.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ItVisShop.Service.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IBaseRepository<Brand> _brandRepository;
        private readonly IProductImageRepository _productImageRepository;
        private readonly IProductPropertyTypeRepository _productPropertyTypeRepository;
        private readonly IProductPropertyRepository _productPropertyRepository;

        public ProductService(IProductRepository productRepository, IBaseRepository<Brand> brandRepository,
            IProductImageRepository productImageRepository, IProductPropertyTypeRepository productPropertyTypeRepository, 
            IProductPropertyRepository productPropertyRepository )
        {
            _productRepository = productRepository;
            _brandRepository = brandRepository;
            _productImageRepository = productImageRepository;
            _productPropertyTypeRepository = productPropertyTypeRepository;
            _productPropertyRepository = productPropertyRepository;
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

        public async Task<IBaseResponse<IEnumerable<Product>>> GetProductsByCategory(string category)
        {
            try
            {
                var products = await _productRepository.GetProductsByCategory(category);

                if (products.Count == 0)
                {
                    return new BaseResponse<IEnumerable<Product>>()
                    {
                        Description = "Найдено 0 элементов",
                        StatusCode = StatusCode.Ok
                    };
                }

                return new BaseResponse<IEnumerable<Product>>()
                {
                    Data = products,
                    StatusCode = StatusCode.Ok
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Product>>()
                {
                    Description = $"{GetProductsByCategory} : {ex.Message}"
                };
            }
        }

        // Получение топовых продуктов продуктов.
        public async Task<IBaseResponse<IEnumerable<Product>>> GetTopProducts()
        {
            try
            {
                var products = await _productRepository.GetAll().OrderByDescending(p => p.CountPurchase).Take(8).ToListAsync();

                if(products.Count == 0)
                {
                    return new BaseResponse<IEnumerable<Product>>()
                    {
                        Description = "Найдено 0 элементов",
                        StatusCode = StatusCode.Ok
                    };
                }

                return new BaseResponse<IEnumerable<Product>>()
                {
                    Data = products,
                    StatusCode = StatusCode.Ok
                };
            }
            catch(Exception ex)
            {
                return new BaseResponse<IEnumerable<Product>>()
                {
                    Description = $"{GetTopProducts} : {ex.Message}"
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<Product>>> SearchProducts(string searchString)
        {
            try
            {
                var products = await _productRepository.GetAll()
                    .Where(p => p.Brand.BrandName.Contains(searchString) || p.Model.Contains(searchString))
                    .ToListAsync();

                if(products.Count == 0)
                {
                    return new BaseResponse<IEnumerable<Product>>()
                    { 
                        Data = products,
                        Description = "Найдено 0 элементов",
                        StatusCode = StatusCode.Ok
                    };
                }

                return new BaseResponse<IEnumerable<Product>>()
                {
                    Data = products,
                    StatusCode = StatusCode.Ok
                };
            }
            catch(Exception ex)
            {
                return new BaseResponse<IEnumerable<Product>>()
                {
                    Description = $"{SearchProducts} : {ex.Message}"
                };
            }
        }

        // Создание продукта.
        public async Task<IBaseResponse<Product>> CreateProduct(CreateProductViewModel model)
        {
            try
            {
                Product product = new Product()
                {
                    BrandId = model.BrandId,
                    ProductTypeId = model.ProductTypeId,
                    Model = model.Model,
                    Price = model.Price,
                    Description = model.Description,
                    MainImage = model.MainImage,
                    AvailableQuantity = model.AvailableQuantity
                };

                List<ProductImage> productImages = new List<ProductImage>();

                foreach(var item in model.Images)
                {
                    var image = new ProductImage()
                    { 
                        Product = product,
                        ImagePath = item
                    };

                    productImages.Add(image);
                }

                List<ProductProperty> properties = new List<ProductProperty>();

                foreach(var item in model.Properties)
                {
                    properties.Add(new ProductProperty
                    {
                        Product = product,
                        ProductPropertyTypeId = item.Id,
                        Value = item.Value
                    });
                }
                
                await _productRepository.Create(product);
                await _productImageRepository.Create(productImages);
                await _productPropertyRepository.CreateAll(properties);

                return new BaseResponse<Product>()
                {
                    Data = product,
                    StatusCode = StatusCode.Ok
                };
            }
            catch(Exception ex)
            {
                return new BaseResponse<Product>()
                {
                    Description = $"{CreateProduct} : {ex.Message}"
                };
            }
        }

        // Получение полей для заполнения.
        public async Task<IBaseResponse<ProductViewModel>> GetProductPropertiesByProductType(int productTypeId)
        {
            try
            {
                ProductViewModel model = new ProductViewModel()
                {
                    Brands = await _brandRepository.GetAll().ToListAsync(),
                    ProductTypeId = productTypeId,
                    ProductPropertyTypes = await _productPropertyTypeRepository.GetAll()
                        .Where(p => p.ProductTypeId == productTypeId).ToListAsync()
                };

                return new BaseResponse<ProductViewModel>()
                {
                    Data = model,
                    StatusCode = StatusCode.Ok
                };
            }
            catch(Exception ex)
            {
                return new BaseResponse<ProductViewModel>()
                {
                    Description = $"{GetProductPropertiesByProductType} : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }   
}       