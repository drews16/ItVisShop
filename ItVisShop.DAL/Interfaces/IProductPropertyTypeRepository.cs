using ItVisShop.Domain.Entity;

namespace ItVisShop.DAL.Interfaces
{
    public interface IProductPropertyTypeRepository : IBaseRepository<ProductPropertyType>
    {
        Task<bool> CreateAll(List<ProductPropertyType> entities);
    }
}
