using ItVisShop.DAL.Interfaces;
using ItVisShop.Domain.Entity;
using ItVisShop.Domain.Enum;
using ItVisShop.Domain.Response;
using ItVisShop.Domain.ViewModels;
using ItVisShop.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ItVisShop.Service.Implementations
{
    public class ProductCartService : IProductCartService
    {
        private readonly IProductCartRepository _productCartRepository;
        private readonly IProductRepository _productRepository;
        private readonly IBaseRepository<User> _userRepository;

        public ProductCartService(IProductCartRepository productCartRepository, IProductRepository productRepository,
            IBaseRepository<User> userRepository)
        {
            _productCartRepository = productCartRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
        }

        // Добавление товара в корзину.
        public async Task<IBaseResponse<ProductCart>> AddInCart(ProductCartViewModel model)
        {
            try
            {
                var user = _userRepository.GetAll()
                    .Include(u => u.Cart)
                        .ThenInclude(c => c.Products)
                    .FirstOrDefault(u => u.Email == model.UserEmail);

                if(user == null)
                {
                    return new BaseResponse<ProductCart>()
                    {
                        Description = "Пользователь не найден",
                        StatusCode = StatusCode.UserNotFound  
                    };
                }

                var product = await _productRepository.Get(model.ProductId);

                var productInCart = user.Cart.Products.FirstOrDefault(p => p.ProductId == product.ProductId);

                if(productInCart != null)
                {
                    productInCart.Count += model.Count;
                    await _productCartRepository.UpdateCart(productInCart);
                }
                else
                {
                    await _productCartRepository.AddInCart(new ProductCart
                    {
                        Count = model.Count,
                        Product = product,
                        ProductId = model.ProductId,
                        Cart = user.Cart,
                        CartId = user.Cart.CartId
                    });
                }

                return new BaseResponse<ProductCart>()
                {
                    StatusCode = StatusCode.Ok
                };
            }
            catch(Exception ex)
            {
                return new BaseResponse<ProductCart>()
                {
                    Description = $"{AddInCart} : {ex.Message}",
                };
            }
        }

        // Удаление всех товаров из корзины.
        public async Task<IBaseResponse<ProductCart>> RemoveAll(string userName)
        {
            try
            {
                var user = await _userRepository.GetAll()
                    .Include(u => u.Cart)
                        .ThenInclude(p => p.Products)
                    .FirstOrDefaultAsync(u => u.Email == userName);

                if(user == null)
                {
                    return new BaseResponse<ProductCart>
                    {
                        Description = "Пользвователь не найден",
                        StatusCode = StatusCode.UserNotFound
                    };
                }

                await _productCartRepository.RemoveAll(user.Cart.Products);

                return new BaseResponse<ProductCart>()
                {
                    StatusCode = StatusCode.Ok
                };
            }
            catch(Exception ex)
            {
                return new BaseResponse<ProductCart>()
                {
                    Description = $"{RemoveAll} : {ex.Message}"
                };
            }
        }

        // Удаление товара из корзины.
        public async Task<IBaseResponse<ProductCart>> RemoveFromCart(int productCartId)
        {
            try
            {
                await _productCartRepository.RemoveFromCart(new ProductCart
                {
                    ProductCartId = productCartId,
                });

                return new BaseResponse<ProductCart>()
                {
                    StatusCode = StatusCode.Ok
                };
            }
            catch(Exception ex)
            {
                return new BaseResponse<ProductCart>()
                {
                    Description = $"{RemoveFromCart} : {ex.Message}",
                };
            }
        }

        // Обновление корзины.
        public async Task<IBaseResponse<bool>> Update(ProductCart entity)
        {
            try
            {
                await _productCartRepository.UpdateCart(entity);

                return new BaseResponse<bool>()
                {
                    Data = true,
                    StatusCode = StatusCode.Ok
                };
            }
            catch(Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"{Update} : {ex.Message}"
                };
            }
        }
    }
}
