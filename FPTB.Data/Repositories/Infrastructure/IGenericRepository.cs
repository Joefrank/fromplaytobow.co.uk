using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;

namespace FPTB.Data.Repositories.Infrastructure
{ 

    public interface IGenericRepository<T>
    {
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);

        T FindFirst(Expression<Func<T, bool>> predicate);

        IEnumerable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");

        T GetById(object id);

        void Insert(T entity);

        void Delete(object id);

        void Delete(T entityToDelete);

        void Update(T entityToUpdate);

    }
}
