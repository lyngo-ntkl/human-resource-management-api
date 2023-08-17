using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public interface IGenericRepository<T> where T: class
    {
        IEnumerable<T> Get();
        T GetById(object id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(object id);
    }
}
