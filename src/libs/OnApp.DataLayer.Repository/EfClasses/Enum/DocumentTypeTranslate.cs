using OnApp.DataLayer.Repository.EfClasses;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnApp.DataLayer.Repository
{
    [Table("enum_document_type_translate")]
    public class DocumentTypeTranslate : 
        TranslateEntity<DocumentTypeTranslate,TranslateColumn>
    {
        [ForeignKey(nameof(LanguageId))]
        public virtual Language Language { get; set; } = null!;
        [ForeignKey(nameof(OwnerId))]
        public virtual DocumentType Owner { get; set; } = null!;
    }
}
