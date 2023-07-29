using Global.Models;

namespace Global.EF
{

    public static class EntityDtoExtensions
    {
        public static void AddTo<TDto, TEntity>(
            this IEnumerable<TDto> dtoList,
            ICollection<TEntity> entityNavigationProperty,
            Action<TEntity, TDto> onAddToNavigationProperty = null) 
                where TDto : EntityDto<TDto, TEntity> 
                                    where TEntity : class
        {
            foreach (TDto dto in dtoList)
            {
                TEntity val = dto.CreateEntity();
                onAddToNavigationProperty?.Invoke(val, dto);
                entityNavigationProperty.Add(val);
            }
        }

        public static void ApplyChangesTo<TDto, TEntity>(
            this IEnumerable<TDto> dtoList,
            ICollection<TEntity> entityNavigationProperty,
            Action<TEntity, TDto> onAddToNavigationProperty = null,
            Action<TEntity, TDto> onUpdateFromNavigationProperty = null,
            Func<TEntity, bool> entityNavigationPropertyFilter = null) where TDto : EntityDto<TDto, TEntity>,
                           IHaveId 
                                where TEntity : class,
                                                IHaveId
        {
            Dictionary<object, TEntity> dictionary 
                    = new Dictionary<object, TEntity>();
            List<TEntity> list = new List<TEntity>();
            
            if (entityNavigationPropertyFilter == null)
                entityNavigationPropertyFilter = (TEntity a) => true;

            foreach (TEntity entity in entityNavigationProperty
                                    .Where(entityNavigationPropertyFilter))
            {
                if (dtoList.Any((TDto dto) => dto.GetId().Equals(entity.GetId())))
                    dictionary.Add(entity.GetId(),
                                   entity);
                else
                    list.Add(entity);
            }

            foreach (TEntity item in list)
                entityNavigationProperty.Remove(item);

            foreach (TDto dto in dtoList)
            {
                if (dictionary.ContainsKey(dto.GetId()))
                {
                    onUpdateFromNavigationProperty?
                        .Invoke(dictionary[dto.GetId()], dto);
                    
                    dto.UpdateEntity(dictionary[dto.GetId()]);
                }
                else
                {
                    TEntity val = dto.CreateEntity();
                    onAddToNavigationProperty?.Invoke(val, dto);
                    entityNavigationProperty.Add(val);
                }
            }

            dictionary.Clear();
        }

        public static void ApplyChangesByStateIdTo<TDto, TEntity>(
            this IEnumerable<TDto> dtoList,
            ICollection<TEntity> entityNavigationProperty,
            Action<TEntity, TDto> onAddToNavigationProperty = null,
            Action<TEntity, TDto> onUpdateFromNavigationProperty = null,
            Func<TEntity, bool> entityNavigationPropertyFilter = null) where TDto : EntityDto<TDto, TEntity>,
                           IHaveId 
                            where TEntity : class,
                                            IHaveId,
                                            IHaveStateId
        {
            Dictionary<object, TEntity> dictionary 
                    = new Dictionary<object, TEntity>();
            List<TDto> list = dtoList.ToList();
            
            if (entityNavigationPropertyFilter == null)
                entityNavigationPropertyFilter
                                = (TEntity a) => true;

            foreach (TEntity entity in entityNavigationProperty.Where(entityNavigationPropertyFilter))
            {
                TDto[] array = list.Where((TDto a) 
                        => a.GetId().Equals(entity.GetId())).ToArray();
                
                if (array.Any())
                {
                    if (entity.StateId == 1)
                    {
                        dictionary.Add(entity.GetId(), entity);
                        continue;
                    }

                    TDto[] array2 = array;
    
                    foreach (TDto item in array2)
                       list.Remove(item);
                }
                else
                    entity.StateId = 2;
            }

            foreach (TDto item2 in list)
            {
                if (dictionary.ContainsKey(item2.GetId()))
                {
                    onUpdateFromNavigationProperty?
                            .Invoke(dictionary[item2.GetId()], item2);
                    
                    item2.UpdateEntity(dictionary[item2.GetId()]);
                }
                else
                {
                    TEntity val = item2.CreateEntity();
                    onAddToNavigationProperty?.Invoke(val, item2);
                    entityNavigationProperty.Add(val);
                }
            }

            dictionary.Clear();
        }

        public static void AddByUniqueFKTo<TDto, TEntity>(this IEnumerable<TDto> dtoList, ICollection<TEntity> entityNavigationProperty, Action<TEntity, TDto> onAddToNavigationProperty = null) where TDto : EntityDto<TDto, TEntity>, IHaveUniqueForeignKey where TEntity : class
        {
            HashSet<object> hashSet = new HashSet<object>();
            foreach (TDto dto in dtoList)
            {
                if (!hashSet.Contains(dto.GetUniqueForeignKey()))
                {
                    hashSet.Add(dto.GetUniqueForeignKey());
                    TEntity val = dto.CreateEntity();
                    onAddToNavigationProperty?.Invoke(val, dto);
                    entityNavigationProperty.Add(val);
                }
            }
        }

        public static void ApplyChangesByUniqueFKTo<TDto, TEntity>(this IEnumerable<TDto> dtoList, ICollection<TEntity> entityNavigationProperty, Action<TEntity, TDto> onAddToNavigationProperty = null, Action<TEntity, TDto> onUpdateFromNavigationProperty = null, Func<TEntity, bool> entityNavigationPropertyFilter = null) where TDto : EntityDto<TDto, TEntity>, IHaveUniqueForeignKey where TEntity : class, IHaveUniqueForeignKey
        {
            Dictionary<object, TEntity> dictionary = new Dictionary<object, TEntity>();
            List<TEntity> list = new List<TEntity>();
            if (entityNavigationPropertyFilter == null)
                entityNavigationPropertyFilter 
                                = (TEntity a) => true;

            foreach (TEntity entity in entityNavigationProperty.Where(entityNavigationPropertyFilter))
            {
                if (dtoList.Any((TDto a) => a.GetUniqueForeignKey().Equals(entity.GetUniqueForeignKey())))
                {
                    if (dictionary.ContainsKey(entity.GetUniqueForeignKey()))
                        list.Add(entity);
                    else
                        dictionary.Add(entity.GetUniqueForeignKey(), entity);
                }
                else
                    list.Add(entity);
            }

            foreach (TEntity item in list)
                entityNavigationProperty.Remove(item);

            foreach (TDto dto in dtoList)
            {
                if (dictionary.ContainsKey(dto.GetUniqueForeignKey()))
                {
                    onUpdateFromNavigationProperty?
                        .Invoke(dictionary[dto.GetUniqueForeignKey()], dto);
               
                    dto.UpdateEntity(dictionary[dto.GetUniqueForeignKey()]);
                }
                else
                {
                    TEntity val = dto.CreateEntity();
                    onAddToNavigationProperty?.Invoke(val, dto);
                    entityNavigationProperty.Add(val);
                }
            }

            dictionary.Clear();
        }

        public static void ApplyChangesByUniqueFKAndStateIdTo<TDto, TEntity>(
            this IEnumerable<TDto> dtoList,
            ICollection<TEntity> entityNavigationProperty,
            Action<TEntity, TDto> onAddToNavigationProperty = null,
            Action<TEntity, TDto> onUpdateFromNavigationProperty = null,
            Func<TEntity, bool> entityNavigationPropertyFilter = null)
                where TDto : EntityDto<TDto, TEntity>,
                             IHaveUniqueForeignKey 
                                    where TEntity : class,
                                                    IHaveUniqueForeignKey,
                                                    IHaveStateId
        {
            Dictionary<object, TEntity> dictionary 
                    = new Dictionary<object, TEntity>();
            
            List<TDto> list = dtoList.ToList();
            
            if (entityNavigationPropertyFilter == null)
                entityNavigationPropertyFilter = (TEntity a) => true;

            foreach (TEntity entity in entityNavigationProperty.Where(entityNavigationPropertyFilter))
            {
                TDto[] array = list.Where((TDto a) => a.GetUniqueForeignKey().Equals(entity.GetUniqueForeignKey())).ToArray();
                
                if (array.Any())
                {
                    if (entity.StateId == 1)
                    {
                        dictionary.Add(entity.GetUniqueForeignKey(),
                                       entity);
                        continue;

                    }

                    TDto[] array2 = array;
                    
                    foreach (TDto item in array2)
                        list.Remove(item);
                }
                else
                    entity.StateId = 2;
            }

            foreach (TDto item2 in list)
            {
                if (dictionary.ContainsKey(item2.GetUniqueForeignKey()))
                {
                    onUpdateFromNavigationProperty?
                            .Invoke(dictionary[item2.GetUniqueForeignKey()], item2);

                    item2.UpdateEntity(dictionary[item2.GetUniqueForeignKey()]);
                }
                else
                {
                    TEntity val = item2.CreateEntity();
                    onAddToNavigationProperty?.Invoke(val, item2);
                    entityNavigationProperty.Add(val);
                }
            }

            dictionary.Clear();
        }

        public static void ApplyChangesTo<TId, TDto, TEntity>(this IEnumerable<TDto> dtoList,
            ICollection<TEntity> entityNavigationProperty,
            Action<TEntity, TDto> onAddToNavigationProperty = null,
            Action<TEntity, TDto> onUpdateFromNavigationProperty = null,
            Func<TEntity, bool> entityNavigationPropertyFilter = null) where TId : struct 
                            where TDto : EntityDto<TDto, TEntity>,
                                  IHaveIdProp<TId> 
                                        where TEntity : class,
                                              IHaveIdProp<TId>
        {
            Dictionary<object, TEntity> dictionary 
                    = new Dictionary<object, TEntity>();

            List<TEntity> list = new List<TEntity>();
            
            if (entityNavigationPropertyFilter == null)
                entityNavigationPropertyFilter = (TEntity a) => true;   

            foreach (TEntity entity in entityNavigationProperty.Where(entityNavigationPropertyFilter))
            {
                if (dtoList.Any((TDto a) => a.Id.Equals(entity.Id)))
                    dictionary.Add(entity.Id, entity);
                else
                    list.Add(entity);
            }

            foreach (TEntity item in list)
                entityNavigationProperty.Remove(item);

            foreach (TDto dto in dtoList)
            {
                if (dictionary.ContainsKey(dto.Id))
                {
                    onUpdateFromNavigationProperty?
                            .Invoke(dictionary[dto.Id], dto);
                    dto.UpdateEntity(dictionary[dto.Id]);
                }
                else
                {
                    TEntity val = dto.CreateEntity();
                    onAddToNavigationProperty?.Invoke(val, dto);
                    entityNavigationProperty.Add(val);
                }
            }

            dictionary.Clear();
        }

        public static void ApplyChangesByStateIdTo<TId, TDto, TEntity>(
            this IEnumerable<TDto> dtoList,
            ICollection<TEntity> entityNavigationProperty,
            Action<TEntity, TDto> onAddToNavigationProperty = null,
            Action<TEntity, TDto> onUpdateFromNavigationProperty = null,
            Func<TEntity, bool> entityNavigationPropertyFilter = null)
                where TId : struct 
                                where TDto :
                                        EntityDto<TDto, TEntity>,
                                        IHaveIdProp<TId> 
                                                where TEntity 
                                                        : class,
                                                          IHaveIdProp<TId>,
                                                          IHaveStateId
        {
            Dictionary<object, TEntity> dictionary 
                    = new Dictionary<object, TEntity>();
            
            List<TDto> list = dtoList.ToList();
            
            if (entityNavigationPropertyFilter == null)
                entityNavigationPropertyFilter = (TEntity a) => true;

            foreach (TEntity entity in entityNavigationProperty.Where(entityNavigationPropertyFilter))
            {
                TDto[] array = list.Where((TDto a) => a.Id.Equals(entity.Id)).ToArray();
                
                if (array.Any())
                {
                    if (entity.StateId == 1)
                    {
                        dictionary.Add(entity.Id, entity);
                        continue;
                    }

                    TDto[] array2 = array;
                    
                    foreach (TDto item in array2)
                        list.Remove(item);
                }
                else
                   entity.StateId = 2;
                
            }

            foreach (TDto item2 in list)
            {
                if (dictionary.ContainsKey(item2.Id))
                {
                    onUpdateFromNavigationProperty?
                            .Invoke(dictionary[item2.Id], item2);
                    
                    item2.UpdateEntity(dictionary[item2.Id]);
                }
                else
                {
                    TEntity val = item2.CreateEntity();
                    onAddToNavigationProperty?.Invoke(val, item2);
                    entityNavigationProperty.Add(val);
                }
            }

            dictionary.Clear();
        }
    }
}
