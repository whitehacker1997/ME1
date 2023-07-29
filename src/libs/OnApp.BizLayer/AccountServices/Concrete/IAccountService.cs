using OnApp.DataLayer.Repository;
using StatusGeneric;

namespace OnApp.BizLayer.AccountServices
{
    public interface IAccountService : 
        IStatusGeneric
    {
        AccountUserDto GetUserInfo();
        void ChangePassword(ChangePasswordDlDto dto);
        void ChangeLanguage(ChangeUserLanguageDlDto dto);
        LoginResultDto Login(LoginDto dto);
    }
}
