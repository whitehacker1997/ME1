using OnApp.DataLayer.Repository.EfClasses;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnApp.DataLayer.Repository
{
    [Table("hl_position_translate")]
    public class PositionTranslate : 
        TranslateEntity<PositionTranslate, TranslateColumn>
    {

        [ForeignKey(nameof(LanguageId))]
        public virtual Language Language { get; set; } = null!;
        [ForeignKey(nameof(OwnerId))]
        public virtual Position Owner { get; set; } = null!;
    }
}
