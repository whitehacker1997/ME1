using GenericServices;
using Global;
using Global.EF;
using Microsoft.EntityFrameworkCore;

namespace OnApp.DataLayer.Repository
{
    public class AccountRepository :
        BaseEntityRepository<int, User>,
        IAccountRepository
    {
        public AccountRepository(ICrudServices crudServices)
            : base(crudServices)
        {
        }


        public void ChangePassword(int userId,
                                   ChangePasswordDlDto dto)
        {
            var entity = ById(userId);

            if (dto.NewPassword.NullOrEmpty())
                AddError(errorMessage: "Новый пароль пустой");
            else if (!entity.IsValidPassword(dto.CurrentPassword))
                AddError(errorMessage: "Текущий пароль неправильно введено");

            if (IsValid)
                dto.UpdateEntity(entity);
        }

        public void ChangeLanguage(int userId,
                                   ChangeUserLanguageDlDto dto)
        {
            var entity = ById(userId);
            dto.UpdateEntity(entity);
        }

        public UserLog AddUserLog(UserLogAction action,
                                  string userName,
                                  int? userId,
                                  string ipAddress,
                                  string userAgent)
        {
            var userLog = new UserLog()
            {
                ActionName = action.ToString(),
                CreatedAt = DateTime.Now,
                UserAgent = userAgent,
                IpAddress = ipAddress,
                UserId = userId,
                UserName = userName,
            };

            Context.Set<UserLog>().Add(userLog);
            Context.Entry(userLog).State = EntityState.Added;

            return userLog;
        }

        public void UpdateUserLastAccessTime(int userId)
        {
            var user = ById(userId);

            user.LastAccessTime = DateTime.Now;
            Context.Entry(user).State = EntityState.Modified;
        }
    }
}
