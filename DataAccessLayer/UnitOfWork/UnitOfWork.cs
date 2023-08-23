using DataAccessLayer.Entities;
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
        private bool disposed = false;
        public UnitOfWork(HumanResourceManagementContext context)
        {
            _context = context;
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IGenericRepository<T> GetRepository<T>() where T : class
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
    }
}
