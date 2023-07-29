using GenericServices;
using Microsoft.EntityFrameworkCore;
using Global.Models;
using StatusGeneric;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace Global.EF
{
    public class BaseEntityRepository<TId, TEntity, TCreateDto, TUpdateDto>
        : BaseEntityRepository<TId, TEntity>,
        IBaseEntityRepository<TId, TEntity, TCreateDto, TUpdateDto>,
        IStatusGenericHandler,
        IStatusGeneric
            where TEntity : class,
        IHaveIdProp<TId>
            where TCreateDto : EntityDto<TCreateDto, TEntity>
            where TUpdateDto : EntityDto<TUpdateDto, TEntity>,
        IHaveIdProp<TId>
    {
        public BaseEntityRepository(ICrudServices crudServices)
            :base(crudServices)
        {

        }

        [Obsolete("This method has deprecated, Use 'Create Validate(TEntity entity, CreateDat dto)' instead")]
        protected virtual void CreateValidate(TCreateDto dto)
        {
        }

        protected virtual void CreateValidate(TEntity entity, TCreateDto dto)
        {
        }

        protected virtual void UpdateValidate(TEntity entity, TUpdateDto dto)
        {
        }

        protected virtual void Validate(TEntity entity,
                                        TCreateDto? createDto,
                                        TUpdateDto? updateDto)
        {
        }
        protected virtual void SetEntityProperties(TEntity? entity,
                                                   TCreateDto createDto,
                                                   TUpdateDto updateDto)
        { 
        }
        public virtual TEntity Create(TCreateDto createDto, Action<TEntity> validation = null)
        {
            if (validation == null)
            {
                CreateValidate(createDto);
            }

            if (base.HasErrors)
            {
                return null;
            }

            TEntity val = createDto.CreateEntity();
            if (base.IsValid)
            {
                if (validation == null)
                {
                    CreateValidate(val, createDto);
                }
                else
                {
                    validation(val);
                }
            }

            OnCreate(val, createDto);
            if (base.HasErrors)
            {
                return null;
            }

            base.DbSet.Add(val);
            base.Context.Entry(val).State = EntityState.Added;
            return val;
        }

        public virtual TEntity Update(TUpdateDto updateDto, Action<TEntity> validation = null)
        {
            TEntity val = ById(updateDto.Id);
            if (base.IsValid)
            {
                if (validation == null)
                {
                    UpdateValidate(val, updateDto);
                }
                else
                {
                    validation(val);
                }
            }

            if (base.HasErrors)
            {
                return null;
            }

            updateDto.UpdateEntity(val);
            OnUpdate(val, updateDto);
            if (base.HasErrors)
            {
                return null;
            }

            base.Context.Entry(val).State = EntityState.Modified;
            return val;
        }
        protected virtual void OnCreate(TEntity entity, TCreateDto dto)
        {
        }

        protected virtual void OnUpdate(TEntity entity, TUpdateDto dto)
        {
        }
    }
}
