namespace Application.Interfaces
{
    public interface IServiceSearchByKeyword<T> where T : class
    {
        Task<IEnumerable<T>> SearchByKeyword(string keyword);
    }
}
