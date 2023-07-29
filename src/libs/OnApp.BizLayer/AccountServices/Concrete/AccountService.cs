using OnApp.Core.Security;
using OnApp.DataLayer.Repository;
using Microsoft.AspNetCore.Http;
using StatusGeneric;
using Global;
using Microsoft.EntityFrameworkCore;

namespace OnApp.BizLayer.AccountServices
{
    public class AccountService :
        StatusGenericHandler,
        IAccountService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IAuthService authService;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IAccountRepository repository;

        public AccountService(
            IUnitOfWork unitOfWork,
            IAuthService authService,
            IHttpContextAccessor httpContextAccessor
            )
        {
            this.unitOfWork = unitOfWork;
            repository = unitOfWork.AccountRepository;
            this.authService = authService;
            this.httpContextAccessor = httpContextAccessor;
        }

        public void ChangeLanguage(ChangeUserLanguageDlDto dto)
        {
            try
            {
                repository.ChangeLanguage(userId: authService.User.Id,
                                          dto: dto);

                CombineStatuses(repository);

                if (IsValid)
                    unitOfWork.Save();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ChangePassword(ChangePasswordDlDto dto)
        {
            try
            {
                repository.ChangePassword(userId: authService.User.Id,
                                          dto: dto);

                CombineStatuses(repository);

                if (IsValid)
                    unitOfWork.Save();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public AccountUserDto GetUserInfo()
        {
            int userId = authService.User.Id;
            var accountUser = repository.ById<AccountUserDto>(id: userId);

            CombineStatuses(repository);
            if (HasErrors)
                return null;

            var hasUserRoles = unitOfWork.Context.Set<UserRole>()
                                                    .IsActive()
                                                    .Include(userRole => userRole.Role)
                                                    .Any(userRole => userRole.UserId == accountUser.Id &&
                                                                     userRole.Role.IsAdmin);

            if (IsValid && hasUserRoles)
                accountUser.Modules = unitOfWork.Context.Set<Module>()
                                                        .Select(module => module.Code)
                                                         .ToList();

            return accountUser;
        }

        public LoginResultDto Login(LoginDto dto)
        {
            if (dto.UserName.NullOrWhiteSpace() ||
                dto.Password.NullOrWhiteSpace())
            {
                AddError("Имя пользователя или пароль неправильно");
                return null;
            }

            var user = repository.AllAsQueryable.Include(a => a.UserRoles)
                                                    .ThenInclude(a => a.Role)
                                                /*.Include(a => a.Employee)*/
                                                .ByUserName(dto.UserName)
                                                .FirstOrDefault();

            if (user == null ||
                !user.IsValidPassword(password: dto.Password))
            {
                AddError("Имя пользователя или пароль неправильно");

                if (user != null)
                    AddUserLog(
                        action: UserLogAction.IncorrectPasswordEntered,
                        userName: user.UserName,
                        userId: user.Id);

                return null;
            }

            bool hasUserRoles = unitOfWork.Context.Set<UserRole>()
                                                  .IsActive()
                                                  .Include(userRole => userRole.Role)
                                                  .Any(userRole => userRole.UserId == user.Id &&
                                                                   userRole.Role.IsAdmin);

            var userModules = new List<string>();

            if (!hasUserRoles)
                userModules = unitOfWork.Context.Set<UserRole>()
                                                .IsActive()
                                                .Include(userRole => userRole.Role)
                                                    .ThenInclude(role => role.RoleModules)
                                                        .ThenInclude(roleModule => roleModule.Module)
                                                .Where(userRole => userRole.UserId == user.Id)
                                                .SelectMany(userRole => userRole.Role.RoleModules)
                                                    .Select(roleModule => roleModule.Module.Code)
                                                .ToList();

            if (IsValid)
            {
                AddUserLog(action: UserLogAction.LoginByPassword,
                           userName: user.UserName,
                           userId: user.Id);

                repository.UpdateUserLastAccessTime(userId: user.Id);

                string token = authService.GenerateToken(userName: user.UserName);

                authService.ResetUserName(userName: user.UserName);

                return new LoginResultDto
                {
                    User = GetUserInfo(),
                    Token = token
                };
            }

            return null;
        }

        private void AddUserLog(UserLogAction action,
                                string userName,
                                int? userId)
        {
            repository.AddUserLog(action: action,
                                  userName: userName,
                                  userId: userId,
                                  ipAddress: authService.UserIp,
                                  userAgent: authService.UserAgent);
            unitOfWork.Save();
        }
    }
}
