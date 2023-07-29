using System.ComponentModel.DataAnnotations.Schema;
using OnApp.DataLayer.Repository.EfClasses;

namespace OnApp.DataLayer.Repository
{
    [Table("info_organization_translate")]
    public class OrganizationTranslate : 
        TranslateEntity<OrganizationTranslate, TranslateColumn>
    {

        [ForeignKey(nameof(LanguageId))]
        public virtual Language Language { get; set; } = null!;
        
        [ForeignKey(nameof(OwnerId))]
        public virtual Organization Owner { get; set; } = null!;
    }
}
