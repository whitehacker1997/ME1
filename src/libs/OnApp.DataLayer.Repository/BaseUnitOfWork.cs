using GenericServices;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace OnApp.DataLayer.Repository
{
    public class BaseUnitOfWork 
        : IBaseUnitOfWork
    {
        private readonly IServiceProvider serviceProvider;

        public BaseUnitOfWork(
              ICrudServices crudServices,
              IServiceProvider serviceProvider)
        {
            Context = (EfCoreContext)crudServices.Context;
            CrudServices = crudServices;
            this.serviceProvider = serviceProvider;
        }
        public ICrudServices CrudServices { get; }
        public EfCoreContext Context { get; }
        
        public TRepository GetRepository<TRepository>() 
                    => this.serviceProvider.GetRequiredService<TRepository>();
        
        public IDbContextTransaction CurrentTransaction { get => Context.Database.CurrentTransaction; }
        
        public IDbContextTransaction BeginTransaction() 
                    => Context.Database.BeginTransaction();
        
        public void Save() 
                => Context.SaveChanges();
       
        public void Commit()
        {
            Save();
            if (Context.Database.CurrentTransaction != null)
                Context.Database.CurrentTransaction.Commit();
        }
        
        public void Rollback()
        {
            Save();
            if (Context.Database.CurrentTransaction != null)
                Context.Database.CurrentTransaction.Commit();
        }
    }
}
