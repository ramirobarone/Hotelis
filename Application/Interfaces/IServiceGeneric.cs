namespace Application.Interfaces
{
    public interface IServiceGeneric<T> where T : class
    {
        Task Create(T entity);

        Task<T> GetById(int id);

        Task<IEnumerable<T>> GetallById(T entity);

        Task Update(T entity);

        Task Delete(int id);
    }
}