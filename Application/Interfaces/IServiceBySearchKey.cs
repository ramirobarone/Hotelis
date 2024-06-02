namespace Application.Interfaces
{
    public interface IServiceBySearchKey<T> where T : class
    {
        Task<IEnumerable<T>> GetBySearchKeyword(string keyword);
    }
}
