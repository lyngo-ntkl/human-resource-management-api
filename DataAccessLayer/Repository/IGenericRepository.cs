using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        T Get(object id);
        Task<T> GetAsync(object id);
        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null);
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter = null);
        T Insert(T entity);
        Task<T> InsertAsync(T entity);
        T Delete(object id);
        T Delete(T entity);
        Task<T> DeleteAsync(object id);
        Task<T> DeleteAsync(T entity);
        T Update(T entity);
        Task<T> UpdateAsync(T entity);
    }
}
