using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;

namespace Infrastructure.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Expression<Func<T, bool>> where);
        Task<T> GetByIdAsync(Expression<Func<T, bool>> where, Func<IQueryable<T>, IIncludableQueryable<T, object>> include);

        Task<IEnumerable<T>> GetAllByIdAsync(Expression<Func<T, bool>> where);
        Task<IEnumerable<T>> GetAllByIdAsync(Expression<Func<T, bool>> where, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy);
        Task<IEnumerable<T>> GetAllByIdAsync(Expression<Func<T, bool>> where, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, Func<IQueryable<T>, IIncludableQueryable<T, object>> include);

        Task UpdateAsync(T entity);

        Task DeleteAsync(int id);

        Task<EntityEntry<T>> CreateAsync(T entity);

        Task<bool> Exist(Expression<Func<T, bool>> where);
    }
}