using GenericServices;
using Microsoft.EntityFrameworkCore;
using Global.Models;
using StatusGeneric;
using System.Linq.Expressions;

namespace Global.EF
{
    public class BaseEntityRepository<TId, TEntity> :
        StatusGenericHandler,
        IBaseEntityRepository<TId, TEntity>,
        IStatusGenericHandler,
        IStatusGeneric
        where TEntity : class,
        IHaveIdProp<TId>
    {
        public BaseEntityRepository(
            ICrudServices crudServices)
        {
            CrudServices = crudServices;
            Context = crudServices.Context;
            DbSet = Context.Set<TEntity>();
        }
        public TId Id { get; set; }
        public DbSet<TEntity> DbSet { get; } = null!;
        public DbContext Context { get; } = null!;
        public ICrudServices CrudServices { get; } = null!;

        protected virtual IQueryable<TEntity> InjectFilter(IQueryable<TEntity> query)
            => query;

        public IQueryable<TEntity> AllAsQueryable
            => InjectFilter(DbSet.AsQueryable());

        protected virtual IQueryable<TEntity> ByIdQuery()
            => AllAsQueryable;

        protected virtual void AddEntityNotFoundError()
            => AddError("По вашему запросу запись не найдено");

        public virtual TEntity ById(TId id)
        {
            TEntity? entity = ByIdQuery()
                                .FirstOrDefault((TEntity a) 
                                                        => a.Id!.Equals(id));

            if (entity == null)
                AddEntityNotFoundError();

            return entity!;
        }

        public IQueryable<TDto> ReadAsNoTracked<TDto>()
            where TDto : class
                => CrudServices
                        .ProjectFromEntityToDto<TEntity, TDto>(InjectFilter);

        public IQueryable<TDto> ReadAsNoTracked<TDto>(Expression<Func<TEntity, bool>> predicate)
            where TDto : class
            => CrudServices.ProjectFromEntityToDto<TEntity, TDto>(
                delegate (IQueryable<TEntity> query)
                {
                    query = InjectFilter(query);
                    return query.Where(predicate);
                });

        public TDto ById<TDto>(TId id)
            where TDto : class
        {
            TDto? dto = ReadAsNoTracked<TDto>((TEntity entity) 
                                                        => entity.Id.Equals(id))
                        .FirstOrDefault();

            if (dto == null)
                AddEntityNotFoundError();

            return dto;

        }
        
        protected virtual void DeleteValidation(TEntity entity) 
        { 
        }
        
        public TEntity Delete(TId id)
        {
            TEntity entity = ById(id);

            if (base.IsValid)
                DeleteValidation(entity);

            if (HasErrors)
                return null!;

            DbSet.Remove(entity);
            Context.Entry(entity).State = EntityState.Deleted;

            return entity;
        }
    }
}
