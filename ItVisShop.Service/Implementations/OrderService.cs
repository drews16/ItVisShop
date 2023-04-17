using ItVisShop.DAL.Interfaces;
using ItVisShop.Domain.Entity;
using ItVisShop.Domain.Extensions;
using ItVisShop.Domain.Response;
using ItVisShop.Domain.ViewModels;
using ItVisShop.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ItVisShop.Service.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IBaseRepository<User> _userRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IBaseRepository<Office> _officeRepository;
        private readonly IOrderProductRepository _orderProductRepository;
        private readonly IProductCartRepository _productCartRepository;

        public OrderService(ICityRepository cityRepository, IBaseRepository<User> userRepository, IOrderRepository orderRepository,
             IBaseRepository<Office> officeRepository, IOrderProductRepository orderProductRepository, IProductCartRepository productCartRepository)
        {
            _cityRepository = cityRepository;
            _userRepository = userRepository;
            _orderRepository = orderRepository;
            _officeRepository = officeRepository;
            _orderProductRepository = orderProductRepository;
            _productCartRepository = productCartRepository;
        }

        // Получение информации о заказе пользователя.
        public async Task<IBaseResponse<OrderViewModel>> GetOrder(string userEmail)
        {
            try
            {
                var user = await _userRepository.GetAll()
                    .Include(u => u.Cart)
                        .ThenInclude(c => c.Products)
                            .ThenInclude(p => p.Product)
                    .FirstOrDefaultAsync(u => u.Email == userEmail);

                if(user == null)
                {
                    return new BaseResponse<OrderViewModel>()
                    {
                        Description = "Пользователь не найден",
                        StatusCode = Domain.Enum.StatusCode.UserNotFound
                    };
                }

                var cities = await _cityRepository.GetCities();
                var officies = await _officeRepository.GetAll()
                    .OrderBy(o => o.City.CityName).ToListAsync();

                var order = new OrderViewModel()
                {
                    User = user,
                    Cities = cities,
                    Officies = officies,
                    ProductCount = user.Cart.Products.Sum(x => x.Count),
                    TotalPrice = user.Cart.Products.Sum(p => (p.Product.Price * p.Count))
                };

                return new BaseResponse<OrderViewModel>()
                {
                    Data = order,
                    StatusCode = Domain.Enum.StatusCode.Ok
                };
            }
            catch(Exception ex)
            {
                return new BaseResponse<OrderViewModel>()
                {
                    Description = $"{GetOrder} : {ex.Message}"
                };
            }
        }

        // Создание заказа.
        public async Task<IBaseResponse<bool>> CreateOrder(CreateOrderViewModel model)
        {
            try
            {
                var user = await _userRepository.GetAll()
                    .Include(u => u.Cart)
                        .ThenInclude(c => c.Products)
                            .ThenInclude(p => p.Product)
                    .FirstOrDefaultAsync(u => u.Email == model.userEmail);

                await _orderRepository.Create(new Order
                {
                    Status = Domain.Enum.OrderStatus.Paid.GetDisplayName(),
                    UserId = user.UserId,
                    OfficeId = model.OfficeId,
                    TotalPrice = user.Cart.Products.Sum(p => p.Product.Price * p.Count)
                });
                
                List<OrderProduct> orderProducts = new List<OrderProduct>();

                foreach(var prod in user.Cart.Products)
                {
                    orderProducts.Add(new OrderProduct()
                    {
                        Product = prod.Product,
                        ProductId = prod.ProductId,
                        OrderId = user.Orders[0].OrderId, // текущий заказ.
                        Count = prod.Count
                    });
                }

                await _orderProductRepository.AddOrderProduct(orderProducts);
                await _productCartRepository.RemoveAll(user.Cart.Products);

                return new BaseResponse<bool>()
                {
                    Data = true,
                    StatusCode = Domain.Enum.StatusCode.Ok
                };
            }
            catch(Exception ex)
            {
                return new BaseResponse<bool>()
                { 
                    Data = false,
                    Description = $"{CreateOrder} : {ex.Message}"
                };
            }
        }
    }
}
