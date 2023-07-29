using GenericServices;
using Microsoft.EntityFrameworkCore;
using Global.Models;
using StatusGeneric;
using System.Linq.Expressions;

namespace Global.EF
{
    public interface IBaseEntityRepository<TId, TEntity> :
        IStatusGenericHandler,
        IStatusGeneric,
        IHaveIdProp<TId>
            where TEntity : class
    { 
        DbSet<TEntity> DbSet { get; }
        DbContext Context { get; }
        ICrudServices CrudServices { get; }
        IQueryable<TEntity> AllAsQueryable { get; }
        IQueryable<TDto> ReadAsNoTracked<TDto>() 
            where TDto : class;
        IQueryable<TDto> ReadAsNoTracked<TDto>(Expression<Func<TEntity, bool>> predicate)
            where TDto : class;
        TEntity ById(TId id);
        TDto ById<TDto>(TId id) 
            where TDto : class;
        TEntity Delete(TId id);
    }

}
