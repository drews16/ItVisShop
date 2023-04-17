using ItVisShop.DAL.Interfaces;
using ItVisShop.Domain.Entity;
using ItVisShop.Domain.Enum;
using ItVisShop.Domain.Response;
using ItVisShop.Domain.ViewModels.Account;
using ItVisShop.Service.Interfaces;
using System.Security.Claims;
using ItVisShop.Domain.Helpers;
using Microsoft.EntityFrameworkCore;
using ItVisShop.Domain.ViewModels;
using ItVisShop.Domain.Extensions;

namespace ItVisShop.Service.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly IBaseRepository<User> _accountRepository;
        private readonly IBaseRepository<User> _userRepository;

        public AccountService(IBaseRepository<User> accountRepository, IBaseRepository<User> userRepository)
        {
            _accountRepository = accountRepository;
            _userRepository = userRepository;
        }

        public async Task<BaseResponse<ClaimsIdentity>> Login(LoginViewModel model)
        {
            try
            {
                var user = await _accountRepository.GetAll()
                    .FirstOrDefaultAsync(u => u.Email == model.Email);
               
                if(user == null)
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Description = "Неверный логин или пароль"
                    };
                }

                if(user.Password != HashPasswordHelper.HashPassword(model.Password, model.Email))
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Description = "Неверный логин или пароль"
                    };
                }

                var result = Authenticate(user);

                return new BaseResponse<ClaimsIdentity>()
                {
                    Data = result,
                    StatusCode = StatusCode.Ok
                };
            }
            catch(Exception ex)
            {
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = ex.Message
                };
            }
        }

        public async Task<BaseResponse<ClaimsIdentity>> Register(RegisterViewModel model)
        {
            try
            {
                var user = await _accountRepository.GetAll()
                    .FirstOrDefaultAsync(u => u.Email == model.Email);

                if(user != null)
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Description = "Пользователь с таким логином уже есть"
                    };
                }

                user = new User()
                {
                    Profile = new Profile
                    {
                        Name = model.Name,
                        Surname = model.Surname,
                        Phone = model.Phone,
                    },
                    Email = model.Email,
                    Password = HashPasswordHelper.HashPassword(model.Password, model.Email),
                    Role = Role.User,
                    Cart = new Cart()
                };

                await _accountRepository.Create(user);

                var result = Authenticate(user);

                return new BaseResponse<ClaimsIdentity>()
                {
                    Data = result,
                    Description = "Пользователь добавлен",
                    StatusCode = StatusCode.Ok
                };
            }
            catch(Exception ex)
            {
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        // Получение заказов пользователя.
        public async Task<IBaseResponse<UserOrdersViewModel>> GetUserOrders(string userEmail)
        {
            try
            {
                var user = await _userRepository.GetAll()
                    .Include(u => u.Orders)
                        .ThenInclude(o => o.Office)
                            .ThenInclude(o => o.City)
                    .FirstOrDefaultAsync(u => u.Email == userEmail);

                if (user == null)
                {
                    return new BaseResponse<UserOrdersViewModel>()
                    {
                        Description = "Пользователь не найден",
                        StatusCode = StatusCode.UserNotFound
                    };
                }

                var orders = new UserOrdersViewModel()
                {
                    User = user,
                    ActiveOrders = user.Orders.Where(o => o.Status == OrderStatus.Paid.GetDisplayName())
                        .OrderByDescending(o => o.DateOfPurchase).ToList(),
                    HistoryOrders = user.Orders.OrderByDescending(o => o.DateOfPurchase).ToList()
                };

                return new BaseResponse<UserOrdersViewModel>()
                {
                    Data = orders,
                    StatusCode = StatusCode.Ok
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<UserOrdersViewModel>()
                {
                    Description = $"{GetUserOrders} : {ex.Message}"
                };
            }
        }

        private ClaimsIdentity Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString()),
                new Claim("UserName", user.Profile.Name)
            };

            return new ClaimsIdentity(claims, "ApplicationCookie", 
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        }
    }
}
