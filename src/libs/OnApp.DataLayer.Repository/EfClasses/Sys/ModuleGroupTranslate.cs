using OnApp.DataLayer.Repository.EfClasses;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnApp.DataLayer.Repository
{
    [Table("sys_module_group_translate")]
    public class ModuleGroupTranslate : EnumTranslateEntity<ModuleGroupTranslate, TranslateColumn>
    {
        [ForeignKey(nameof(LanguageId))]
        public virtual Language Language { get; set; } = null!;
        [ForeignKey(nameof(OwnerId))]
        public virtual ModuleGroup Owner { get; set; } = null!;
    }
}
