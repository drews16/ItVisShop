namespace ItVisShop.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<bool> Create(T entity);

        Task<bool> Delete(T entity);

        Task<T> Get(int id);
        Task<List<T>> Select();
    }
}
