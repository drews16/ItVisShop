using ItVisShop.DAL.Interfaces;
using ItVisShop.DAL.Repositories;
using ItVisShop.Domain.Entity;
using ItVisShop.Service.Implementations;
using ItVisShop.Service.Interfaces;

namespace ItVisShop
{
    public static class Initializer
    {
        public static void InitializeRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IBaseRepository<User>, AccountRepository>();
            services.AddScoped<IBaseRepository<Cart>, CartRepository>();
            services.AddScoped<IProductCartRepository, ProductCartRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IBaseRepository<Office>, OfficeRepository>();
            services.AddScoped<IOrderProductRepository, OrderProductRepository>();
            services.AddScoped<IBaseRepository<Brand>, BrandRepository>();
            services.AddScoped<IBaseRepository<ProductType>, ProductTypeRepository>();
            services.AddScoped<IProductImageRepository, ProductImageRepository>();
            services.AddScoped<IProductPropertyTypeRepository, ProductPropertyTypeRepository>();
            services.AddScoped<IProductPropertyRepository, ProductPropertyRepository>();
            services.AddScoped<IBaseRepository<ProductType>, ProductTypeRepository>();
            services.AddScoped<IBaseRepository<Review>, ReviewRepository>();
        }

        public static void InitializeServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IProductCartService, ProductCartService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IProductTypeService, ProductTypeService>();
            services.AddScoped<IReviewService, ReviewService>();
        }
    }
}
