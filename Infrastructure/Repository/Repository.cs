using Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using System.Collections;
using Infrastructure.Context;

namespace Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly HotelisContext _hotelisContext;
        private DbSet<T> dbSet;
        public Repository(HotelisContext hotelisContext)
        {
            _hotelisContext = hotelisContext;

            dbSet = _hotelisContext.Set<T>();
        }
        public async Task<T> GetByIdAsync(Expression<Func<T, bool>> where)
        {
            if (where is null)
                return default;

            var response = await dbSet.Where(where).FirstOrDefaultAsync();
            return response;
        }

        public async Task<IEnumerable<T>> GetAllByIdAsync(Expression<Func<T, bool>> where = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = dbSet;

            if (where != null)
            {
                query = query.Where(where);
            }

            if (include != null)
            {
                query = include(query);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public Task UpdateAsync(T entity)
        {
            dbSet.Attach(entity);
            _hotelisContext.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }


        public async Task DeleteAsync(int id)
        {
            if (dbSet != null)
            {
                if (id != null)
                {

                    T entityToDelete = await dbSet.FindAsync(id);
                    if (entityToDelete != null)
                    {
                        await DeleteAsync(entityToDelete);
                    }
                }
            }
        }
        private Task DeleteAsync(T entity)
        {
            if (_hotelisContext.Entry(entity).State == EntityState.Deleted)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task CreateAsync(T entity)
        {
            await dbSet.AddAsync(entity);
        }
    }
}