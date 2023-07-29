using Global.Attributes;
using Global.EF;
using Global.Models;

namespace OnApp.DataLayer.Repository
{
    public class TranslateDto<TTranslateDto,TEntity,TTranslateColumn> :
        EntityDto<TTranslateDto,TEntity>,
        IHaveUniqueForeignKey
            where TTranslateDto : EntityDto<TTranslateDto,TEntity>
            where TEntity : class
            where TTranslateColumn : struct
    {
        [LocalizedRequired]
        public virtual TTranslateColumn ColumnName { get; set; }
        [LocalizedRequired]
        [LocalizedRange(1, int.MaxValue)]
        public int LanguageId { get; set; }
        [LocalizedRequired]
        public string TranslateText { get; set; }

        public object GetUniqueForeignKey() 
            => $"{ColumnName}_{LanguageId}";
    }
}
