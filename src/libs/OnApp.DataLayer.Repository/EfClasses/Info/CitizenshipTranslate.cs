using OnApp.DataLayer.Repository.EfClasses;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnApp.DataLayer.Repository
{
    [Table("info_citizenship_translate")]
    public class CitizenshipTranslate :
        TranslateEntity<CitizenshipTranslate,TranslateColumn>
    {
        [ForeignKey(nameof(LanguageId))]
        public virtual Language Language { get; set; } = null!;
        [ForeignKey(nameof(OwnerId))]
        public virtual Citizenship Owner { get; set; } = null!;
    }
}
