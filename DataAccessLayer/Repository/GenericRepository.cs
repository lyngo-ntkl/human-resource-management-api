using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private static HumanResourceManagementContext _context;
        private static DbSet<T> Values { get; set; }
        public GenericRepository(HumanResourceManagementContext context)
        {
            _context = context;
            Values = _context.Set<T>();
        }

        public T Get(object id)
        {
            return Values.Find(id);
        }

        public async Task<T> GetAsync(object id)
        {
            return await Values.FindAsync(id);
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = Values;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return query.ToList();
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = Values;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();
        }

        public T Insert(T entity)
        {
            var value = Values.Add(entity);
            _context.SaveChanges();
            return value.Entity;
        }

        public async Task<T> InsertAsync(T entity)
        {
            var value = await Values.AddAsync(entity);
            _context.SaveChanges();
            return value.Entity;
        }

        public T Delete(object id)
        {
            T entity = Values.Find(id);
            if (entity == null)
            {
                return null;
            }
            return Values.Remove(entity).Entity;
        }

        public T Delete(T entity)
        {
            return Values.Remove(entity).Entity;
        }

        public async Task<T> DeleteAsync(object id)
        {
            var value = await Values.FindAsync(id);
            if (value == null)
            {
                return null;
            }
            await _context.SaveChangesAsync();
            return Values.Remove(value).Entity;
        }

        public Task<T> DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public T Update(T entity)
        {
            var value = Values.Update(entity);
            _context.SaveChanges();
            return value.Entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var value = Values.Update(entity);
            await _context.SaveChangesAsync();
            return value.Entity;
        }
    }

    public static class DynamicFilter
    {
        public static IQueryable<T> Filter<T>(this IQueryable<T> source, T filter)
        {
            foreach (var property in filter.GetType().GetProperties())
            {
                if (filter.GetType().GetProperty(property.Name) != null)
                {
                    object data = filter.GetType().GetProperty(property.Name).GetValue(filter);
                    //later
                }
            }
            return source;
        }
    }
}
