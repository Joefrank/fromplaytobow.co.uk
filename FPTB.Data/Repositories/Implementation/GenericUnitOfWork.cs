using bigbus.checkout.data.Repositories.Implementation;
using FPTB.Data.Repositories.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;

namespace FPTB.Data.Repositories.Implementation
{
    public class GenericUnitOfWork : IUnitOfWork
    {
        private DbContext _context;

        private bool _disposed;

        public GenericUnitOfWork(DbContext dbContext)
        {
            _context = dbContext;
        }     

        public Dictionary<Type, object> Repositories = new Dictionary<Type, object>();

        public IGenericRepository<T> Repository<T>() where T : class
        {
            if (Repositories.Keys.Contains(typeof(T)))
            {
                return Repositories[typeof(T)] as IGenericRepository<T>;
            }

            IGenericRepository<T> repo = new GenericRepository<T>(_context);
            Repositories.Add(typeof(T), repo);
            return repo;
        }

        public void CommitChanges()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var temp = ex;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}
