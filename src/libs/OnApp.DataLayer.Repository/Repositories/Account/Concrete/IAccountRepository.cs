using Global.EF;

namespace OnApp.DataLayer.Repository
{
    public interface IAccountRepository : 
        IBaseEntityRepository<int,User>
    {
        void ChangePassword(int userId,
                            ChangePasswordDlDto dto);
        void ChangeLanguage(int userId,
                            ChangeUserLanguageDlDto dto);
        UserLog AddUserLog(UserLogAction action,
                           string userName,
                           int? userId,
                           string ipAddress,
                           string userAgent);

        void UpdateUserLastAccessTime(int userId);
    }
}
