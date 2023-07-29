using OnApp.DataLayer.Repository.EfClasses;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnApp.DataLayer.Repository;

[Table("enum_state_translate")]
public class StateTranslate : 
    EnumTranslateEntity<StateTranslate,TranslateColumn>
{
    [ForeignKey(nameof(LanguageId))]
    public virtual Language Language { get; set; } = null!;

    [ForeignKey(nameof(OwnerId))]
    public virtual State Owner { get; set; } = null!;
}
