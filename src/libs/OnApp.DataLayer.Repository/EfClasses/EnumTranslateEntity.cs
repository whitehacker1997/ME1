using Global.EF;
using Global.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using OnApp.Core;

namespace OnApp.DataLayer.Repository.EfClasses
{
    public abstract class EnumTranslateEntity<TTranslate, TTranslateColumn> :
        EnumTranslateEntity<TTranslate, TTranslateColumn, int>
            where TTranslate : 
                    EnumTranslateEntity<TTranslate, TTranslateColumn>
            where TTranslateColumn : struct
    {

    }
    public abstract class EnumTranslateEntity<TTranslate,TTranslateColumn,TOwnerId> :
         IHaveUniqueForeignKey,
         ITranslate
            where TTranslate : 
                    EnumTranslateEntity<TTranslate,TTranslateColumn,TOwnerId>
            where TTranslateColumn : struct
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("owner_id")]
        public TOwnerId OwnerId { get; set; }
        [Column("language_id")]
        public int LanguageId { get; set; }
        [Required]
        [Column("column_name")]
        [StringLength(100)]
        public string ColumnName { get; set; }
        [Required]
        [Column("translate_text")]
        public string TranslateText { get; set; }

        [Column("created_at",
                TypeName = "timestamp without time zone")]
        public DateTime DateOfCreated { get; set; }
        
        public object GetUniqueForeignKey()
             => $"{ColumnName}_{LanguageId}";
        public static Expression<Func<TTranslate, bool>> GetExpr(
            TTranslateColumn column,
            int languageId
            )
        {
            string columnName 
                = column.ToString();

            return ttranslate => ttranslate.LanguageId == languageId &&
                                 ttranslate.ColumnName == columnName;
        }

        public static Expression<Func<TTranslate, bool>> GetExpr(TTranslateColumn column)
        {
            string columnName = column.ToString();

            return ttranslate => ttranslate.LanguageId ==
                                    ServiceProvider.CultureHelper.CurrentCulture.Id &&

              ttranslate.ColumnName == columnName;
        }
    }
}
