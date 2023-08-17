using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class GenericRepository<T>: IGenericRepository<T> where T : class
    {
        private static HumanResourceManagementContext _context;
        private static DbSet<T> Values { get; set; }
        public GenericRepository(HumanResourceManagementContext context)
        {
            _context = context;
            Values = _context.Set<T>();
        }

        public IEnumerable<T> Get()
        {
            return Values.ToList();
        }

        public T GetById(object id)
        {
            return Values.Find(id);
        }

        public void Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public void Delete(object id)
        {
            T entity = Values.Find(id);
            _context.Remove(entity);
        }
    }
}
