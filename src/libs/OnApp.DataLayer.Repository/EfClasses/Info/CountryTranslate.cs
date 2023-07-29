using OnApp.DataLayer.Repository.EfClasses;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnApp.DataLayer.Repository
{
    [Table("info_country_translate")]
    public class CountryTranslate :
        TranslateEntity<CountryTranslate, TranslateColumn>
    {

        [ForeignKey(nameof(LanguageId))]
        public virtual Language Language { get; set; } = null!;
        [ForeignKey(nameof(OwnerId))]
        public virtual Country Owner { get; set; } = null!;
    }
}
