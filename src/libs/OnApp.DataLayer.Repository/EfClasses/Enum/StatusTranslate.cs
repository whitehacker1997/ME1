using OnApp.DataLayer.Repository.EfClasses;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnApp.DataLayer.Repository
{
    [Table("enum_status_translate")]
    public partial class StatusTranslate 
        : TranslateEntity<StatusTranslate,TranslateColumn>
    {
        [ForeignKey(nameof(LanguageId))]
        public virtual Language Language { get; set; } = null!;
        [ForeignKey(nameof(OwnerId))]
        public virtual Status Owner { get; set; } = null!;
    }
}
