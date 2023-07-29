using Global.Attributes;
using Global.EF;

namespace OnApp.DataLayer.Repository
{
    public class ChangeUserLanguageDlDto :
        EntityDto<ChangePasswordDlDto, User>
    {
        [LocalizedRequired]
        [LocalizedRange(1, int.MaxValue)]
        public int LanguageId { get; set; }
    }
}
