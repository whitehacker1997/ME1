using OnApp.Core;
using OnApp.DataLayer;
using OnApp.DataLayer.Repository;
using Global.Models;

namespace OnApp.BizLayer.EnumServices
{
    public static class DocumentTypeSelectList
    {
        public static SelectList<int> AsSelectList(this IQueryable<DocumentType> source)
        {
            return new SelectList<int>(source.Select(documentType 
                => new SelectListItem<int> {
                    Value = documentType.Id,
                    Text = documentType.Translates.
                            AsQueryable()
                                .FirstOrDefault(DocumentTypeTranslate.GetExpr(TranslateColumn.full_name,
                                                                        ServiceProvider.CultureHelper.CurrentCulture.Id)).TranslateText ??
                                                                        documentType.FullName
                }));
        }
    }
}
