using ItVisShop.Domain.Entity;

namespace ItVisShop.DAL.Interfaces
{
    public interface IProductPropertyRepository : IBaseRepository<ProductProperty>
    {
        Task<bool> CreateAll(List<ProductProperty> entities);
    }
}
