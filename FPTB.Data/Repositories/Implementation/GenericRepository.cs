using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using FPTB.Data.Repositories.Infrastructure;
using System.Linq.Expressions;

namespace FPTB.Data.Repositories.Implementation
{
    public abstract class GenericRepository<T> :
    IGenericRepository<T>
        where T : class        
    {

        private DbContext _entities;
        private IDbSet<T> _dbset;

        protected DbContext Context
        {
            get { return _entities; }
            set { _entities = value; }
        }

        protected IDbSet<T> DBSet
        {
            get { return _dbset; }
            set { _dbset = value; }
        }

        public GenericRepository(DbContext context)
        {
            _entities = context;
            _dbset = context.Set<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            IEnumerable<T> query = _dbset.AsEnumerable<T>();
            return query;
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> query = _dbset.Where(predicate);
            return query;
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            var result = _dbset.Where(predicate);
            if (result.Any())
            {
                T query = result.FirstOrDefault();
                return query;
            }
            return null;
        }

        public virtual void Add(T entity)
        {
            _dbset.Add(entity);
        }

        public virtual void Delete(T entity)
        {
            _dbset.Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
        }

        public virtual int Save()
        {
            try
            {
               return _entities.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
