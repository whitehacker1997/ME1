using OnApp.DataLayer.Repository.EfClasses;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnApp.DataLayer.Repository
{
    [Table("info_nationality_translate")]
    public class NationalityTranslate :
        TranslateEntity<NationalityTranslate, TranslateColumn>
    {

        [ForeignKey(nameof(LanguageId))]
        public virtual Language Language { get; set; } = null!;
        [ForeignKey(nameof(OwnerId))]
        public virtual Nationality Owner { get; set; } = null!;
    }
}
