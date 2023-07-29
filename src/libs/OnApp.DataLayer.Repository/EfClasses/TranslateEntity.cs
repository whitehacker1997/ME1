using System.ComponentModel.DataAnnotations.Schema;

namespace OnApp.DataLayer.Repository.EfClasses
{
    public abstract class TranslateEntity<TTranslateEntity, TTranslateColumn> :
        TranslateEntity<TTranslateEntity, TTranslateColumn, int>
            where TTranslateEntity : TranslateEntity<TTranslateEntity, TTranslateColumn>
            where TTranslateColumn : struct
    {

    }

    public abstract class TranslateEntity<TTranslateEntity, TTranslateColumn, TOwnerId> :
        EnumTranslateEntity<TTranslateEntity, TTranslateColumn, TOwnerId>
            where TTranslateEntity : TranslateEntity<TTranslateEntity, TTranslateColumn, TOwnerId>
            where TTranslateColumn : struct
    {
        [Column("created_by")]
        public int? CreatedBy { get; set; }
        [Column("modified_at", TypeName = "timestamp without time zone")]
        public DateTime? ModifiedAt { get; set; }
        [Column("modified_by")]
        public int? ModifiedBy { get; set; }
    }
}
