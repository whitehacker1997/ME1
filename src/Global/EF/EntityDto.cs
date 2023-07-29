using AutoMapper;

namespace Global.EF
{
    public class EntityDto<TDto, TEntity>
        : IEntityDto<TEntity>
            where TDto :
                    EntityDto<TDto, TEntity>
            where TEntity : class
    {
        private TEntity entity;
        protected virtual Action<IMappingExpression<TDto, TEntity>> AlterMapping => null;
        protected virtual Action<IMappingExpression<TDto, TEntity>> AlterCreateMapping => null;
        protected virtual Action<IMappingExpression<TDto, TEntity>> AlterUpdateMapping => null;

        public TEntity GetEntity() => entity;
        public virtual TEntity CreateEntity()
        {
            if (AlterMapping != null)
                entity = new MapperConfiguration(delegate (IMapperConfigurationExpression config)
                {
                    AlterMapping(config.CreateMap<TDto, TEntity>());
                }).CreateMapper()
                    .Map<TEntity>((TDto)this);
            else if (AlterCreateMapping != null)
                entity = new MapperConfiguration(delegate (IMapperConfigurationExpression config)
                {
                    AlterCreateMapping(config.CreateMap<TDto, TEntity>());
                }).CreateMapper()
                    .Map<TEntity>((TDto)this);
            else
                entity = new MapperConfiguration(delegate (IMapperConfigurationExpression config)
                {
                    config.CreateMap<TDto, TEntity>();
                }).CreateMapper()
                    .Map<TEntity>((TDto)this);

            return entity;
        }
        public virtual void UpdateEntity(TEntity entity)
        {
            this.entity = entity;
            MapperConfiguration mapperConfiguration = null;

            mapperConfiguration = ((AlterUpdateMapping != null) ?
                                                new MapperConfiguration(delegate (IMapperConfigurationExpression config) {
                                                    AlterUpdateMapping(config.CreateMap<TDto, TEntity>());
                                                }) :
                                    ((AlterMapping != null) ?
                                                new MapperConfiguration(delegate (IMapperConfigurationExpression config) {
                                                    AlterMapping(config.CreateMap<TDto, TEntity>());
                                                }) : 
                                                new MapperConfiguration(delegate (IMapperConfigurationExpression config) {
                                                    config.CreateMap<TDto, TEntity>();
                                                }))        
                                   );

            mapperConfiguration.CreateMapper().Map((TDto)this, entity);
        }
    }
}
