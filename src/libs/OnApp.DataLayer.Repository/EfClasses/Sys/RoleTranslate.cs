using System.ComponentModel.DataAnnotations.Schema;
using OnApp.DataLayer.Repository.EfClasses;

namespace OnApp.DataLayer.Repository
{
    [Table("sys_role_translate")]
    public class RoleTranslate : 
        TranslateEntity<RoleTranslate,TranslateColumn>
    {
        [ForeignKey(nameof(LanguageId))]
        public virtual Language Language { get; set; } = null!;
        [ForeignKey(nameof(OwnerId))]
        public virtual Role Owner { get; set; } = null!;
    }
}
