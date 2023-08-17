using BusinessObjects.Models;
using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HumanResourceManagementContext _context;
        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

        public IGenericRepository<T> Repository<T>() where T : class
        {
            Type type = typeof(T);
            if(!_repositories.TryGetValue(type, out var repository))
            {
                var repository1 = new GenericRepository<T>(_context);
                _repositories.Add(type, repository1);
                return repository1;
            }
            return repository as GenericRepository<T>;
        }

        public UnitOfWork(HumanResourceManagementContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }
    }
}
