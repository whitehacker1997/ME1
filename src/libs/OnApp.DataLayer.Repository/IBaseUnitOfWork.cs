using Microsoft.EntityFrameworkCore.Storage;

namespace OnApp.DataLayer.Repository
{
    public interface IBaseUnitOfWork
    {
        EfCoreContext Context { get; }
        IDbContextTransaction CurrentTransaction { get; }
        TRepository GetRepository<TRepository>();
        IDbContextTransaction BeginTransaction();
        void Save();
        void Commit();
        void Rollback();
    }
}
