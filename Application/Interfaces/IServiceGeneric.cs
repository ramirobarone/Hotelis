namespace Application.Interfaces
{
    public interface IServiceGeneric<T> where T : class
    {
        Task<T> Create(T entity);

        Task<T> GetById(int id);

        Task<IEnumerable<T>> GetAllById(int entity);

        Task Update(T entity);

        Task Delete(int id);
    }
}