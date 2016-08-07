using System;


namespace FPTB.Data.Repositories.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {       
        IGenericRepository<T> Repository<T>() where T : class;

        void CommitChanges();

    }
}
