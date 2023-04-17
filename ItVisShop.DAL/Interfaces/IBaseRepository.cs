namespace ItVisShop.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<bool> Create(T entity);

        Task<bool> Delete(T entity);
        Task<T> Get(int id);
        IQueryable<T> GetAll();
        Task<bool> Update(T entity);
    }
}
