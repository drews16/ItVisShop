using ItVisShop.Domain.Enum;

namespace ItVisShop.Domain.Response
{
    public class BaseResponse<T> : IBaseResponse<T>
    {
        public string? Description { get; set; }
        public StatusCode StatusCode { get; set; }
        public T Data { get; set; }
    }

    public interface IBaseResponse<T>
    {
        public string Description { get; }
        public StatusCode StatusCode { get; }
        T Data { get; }
    }
}
