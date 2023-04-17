using ItVisShop.DAL.Interfaces;
using ItVisShop.Domain.Entity;
using ItVisShop.Domain.Enum;
using ItVisShop.Domain.Response;
using ItVisShop.Domain.ViewModels;
using ItVisShop.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ItVisShop.Service.Implementations
{
    public class CartService : ICartService
    {
        private readonly IProductRepository _productRepository;
        private readonly IBaseRepository<User> _userRepository;

        public CartService(IProductRepository productRepository, IBaseRepository<User> userRepository)
        {
            _productRepository = productRepository;
            _userRepository = userRepository;
        }

        // Получение корзины пользоавтеля.
        public async Task<IBaseResponse<CartViewModel>> GetItems(string userId)
        {
            try
            {
                var user = _userRepository.GetAll()
                    .Include(u => u.Cart)
                    .ThenInclude(c => c.Products)
                        .ThenInclude(p => p.Product)
                            .ThenInclude(p => p.Brand)
                     .Include(u => u.Cart)
                        .ThenInclude(c => c.Products)
                            .ThenInclude(x => x.Product)
                                .ThenInclude(x => x.ProductType)
                    .FirstOrDefault(u => u.Email == userId);

                if (user == null)
                {
                    return new BaseResponse<CartViewModel>()
                    {
                        Description = "Пользователь не найден",
                        StatusCode = StatusCode.UserNotFound
                    };
                }

                decimal totalPrice = user.Cart.Products.Sum(p => p.Product.Price * p.Count);
                int productCount = user.Cart.Products.Sum(p => p.Count);


                return new BaseResponse<CartViewModel>()
                {
                    Data = new CartViewModel
                    {
                        UserId = user.UserId,
                        Products = user.Cart.Products,
                        TotalPrice = totalPrice,
                        ProductCount = productCount
                    },
                    StatusCode = StatusCode.Ok
                };
            }
            catch(Exception ex)
            {
                return new BaseResponse<CartViewModel>()
                {
                    Description = $"{GetItems} : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public Task<IBaseRepository<Cart>> RemoveProductFromCart(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
