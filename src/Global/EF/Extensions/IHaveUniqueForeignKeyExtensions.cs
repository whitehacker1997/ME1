using Global.Models;

namespace Global.EF
{
    public static class IHaveUniqueForeignKeyExtensions
    {
        public static void AddFromForeignKeys<TForeignKey, TManyToManyEntity>(
            this ICollection<TManyToManyEntity> manyToManyEntityNavigationProperty,
            IEnumerable<TForeignKey> foreignKeyList) 
                where TManyToManyEntity : class,
                                          IHaveSingleUniqueForeignKey<TForeignKey>
        {
            foreach (TForeignKey foreignKey in foreignKeyList)
            {
                TManyToManyEntity val 
                    = Activator.CreateInstance<TManyToManyEntity>();

                val.SetUniqueForeignKey(foreignKey);
                manyToManyEntityNavigationProperty.Add(val);
            }
        }

        public static void UpdateFromForeignKeys<TForeignKey, TManyToManyEntity>(
            this ICollection<TManyToManyEntity> manyToManyEntityNavigationProperty,
            IEnumerable<TForeignKey> foreignKeyList) 
                where TManyToManyEntity : class,
                                          IHaveSingleUniqueForeignKey<TForeignKey>
        {
            HashSet<TForeignKey> foundedEntitiesForeignKeys 
                                            = new HashSet<TForeignKey>();

            foreach (TManyToManyEntity item in manyToManyEntityNavigationProperty)
                if (foreignKeyList.Contains((TForeignKey)item.GetUniqueForeignKey()))
                    if (foundedEntitiesForeignKeys.Contains((TForeignKey)item.GetUniqueForeignKey()))
                        manyToManyEntityNavigationProperty.Remove(item);
                    else
                        foundedEntitiesForeignKeys.Add((TForeignKey)item.GetUniqueForeignKey());
                else
                    manyToManyEntityNavigationProperty.Remove(item);

            manyToManyEntityNavigationProperty.AddFromForeignKeys(
                foreignKeyList.Where((TForeignKey a) => !foundedEntitiesForeignKeys.Contains(a)));

            foundedEntitiesForeignKeys.Clear();
        }

        public static void UpdateByStateIdFromForeignKeys<TForeignKey, TManyToManyEntity>(
            this ICollection<TManyToManyEntity> manyToManyEntityNavigationProperty,
            IEnumerable<TForeignKey> foreignKeyList) 
                where TManyToManyEntity : class,
                                          IHaveSingleUniqueForeignKey<TForeignKey>,
                                          IHaveStateId
        {
            HashSet<TForeignKey> foundedEntitiesForeignKeys 
                                            = new HashSet<TForeignKey>();

            foreach (TManyToManyEntity item in manyToManyEntityNavigationProperty)
                if (foreignKeyList.Contains((TForeignKey)item.GetUniqueForeignKey()))
                    if (item.StateId == 1)
                        foundedEntitiesForeignKeys.Add((TForeignKey)item.GetUniqueForeignKey());
                else
                    item.StateId = 2;

            manyToManyEntityNavigationProperty.AddFromForeignKeys(
                foreignKeyList.Where((TForeignKey a) => !foundedEntitiesForeignKeys.Contains(a)));

            foundedEntitiesForeignKeys.Clear();
        }
    }
}
