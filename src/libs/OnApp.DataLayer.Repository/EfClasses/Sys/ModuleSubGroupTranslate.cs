using OnApp.DataLayer.Repository.EfClasses;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnApp.DataLayer.Repository
{
    [Table("sys_module_sub_group_translate")]
    public class ModuleSubGroupTranslate : 
        TranslateEntity<ModuleSubGroupTranslate,TranslateColumn>
    {
        [ForeignKey(nameof(LanguageId))]
        public virtual Language Language { get; set; } = null!;
        [ForeignKey(nameof(OwnerId))]
        public virtual ModuleSubGroup Owner { get; set; } = null!;
    }
}
