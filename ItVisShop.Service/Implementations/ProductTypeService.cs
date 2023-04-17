using ItVisShop.DAL.Interfaces;
using ItVisShop.Domain.Entity;
using ItVisShop.Domain.Response;
using ItVisShop.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ItVisShop.Service.Implementations
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly IBaseRepository<ProductType> _productTypeRepository;

        public ProductTypeService(IBaseRepository<ProductType> productTypeRepository)
        {
            _productTypeRepository = productTypeRepository;
        }

        public async Task<IBaseResponse<IEnumerable<ProductType>>> GetProductTypes()
        {
            try
            {
                var productTypes = await _productTypeRepository.GetAll().ToListAsync();

                if(productTypes.Count == 0)
                {
                    return new BaseResponse<IEnumerable<ProductType>>()
                    {
                        Description = "Найдено 0 элементов",
                        StatusCode = Domain.Enum.StatusCode.Ok
                    };
                }

                return new BaseResponse<IEnumerable<ProductType>>()
                { 
                    Data = productTypes,
                    StatusCode = Domain.Enum.StatusCode.Ok
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<ProductType>>()
                {
                    Description = $"{GetProductTypes} : {ex.Message}",
                    StatusCode = Domain.Enum.StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<ProductType>> GetProductType(int id)
        {
            try
            {
                var productType = await _productTypeRepository.Get(id);

                if(productType == null)
                {
                    return new BaseResponse<ProductType>
                    {
                        Description = "Тип категории не найден",
                        StatusCode = Domain.Enum.StatusCode.InternalServerError
                    };
                }

                return new BaseResponse<ProductType>
                {
                    Data = productType,
                    StatusCode = Domain.Enum.StatusCode.Ok
                };
            }
            catch(Exception ex)
            {
                return new BaseResponse<ProductType>
                { 
                    Description = $"{GetProductType} : {ex.Message}",
                    StatusCode = Domain.Enum.StatusCode.InternalServerError
                };
            }
        }
    }
}
