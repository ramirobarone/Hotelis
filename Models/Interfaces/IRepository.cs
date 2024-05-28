using System.Threading;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Models.Interfaces
{
    public interface IRepository<T>  where T : class
    {
        Task<T> GetByIdAsync(Expression<Func<T, bool>> where);

        Task<IEnumerable<T>> GetAllByIdAsync(Expression<Func<T, bool>> where = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);

        Task UpdateAsync(T entity);

        Task DeleteAsync(int id);

        Task CreateAsync(T entity);
    }
}