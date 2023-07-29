using OnApp.DataLayer.Repository.EfClasses;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnApp.DataLayer.Repository
{
    [Table("enum_gender_translate")]
    public class GenderTranslate : 
        TranslateEntity<GenderTranslate,TranslateColumn>
    {
        [ForeignKey(nameof(LanguageId))]
        public virtual Language Language { get; set; } = null!;
        [ForeignKey(nameof(OwnerId))]
        public virtual Gender Owner { get; set; } = null!;
    }
}
