using OnApp.Core;
using OnApp.Core.Security;
using OnApp.DataLayer.Repository;

namespace OnApp.BizLayer.AccountServices
{
    public static class UserAuthModelSelect
    {
        public static IQueryable<UserAuthModel> MapToAuthModel(this IQueryable<User> users)
            => users.Select(user => new UserAuthModel
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Inn= user.Person.Inn,
                    Pinfl= user.Person.Pinfl,
                    FullName= $"{user.Person.LastName} {user.Person.FirstName} {user.Person.MiddleName}",
                    IsAdmin = user.UserRoles.Where(userRole 
                                        => userRole.StateId == StateIdConst.ACTIVE)
                                                .Any(userRole => userRole.Role.IsAdmin),
                    LanguageId = user.LanguageId,
                    LanguageCode = user.Language.Code,
                    OrganizationId= user.OrganizationId,
        //            PositionId = user.Employee != null ? async.Employee.PositionId: null,
                    Modules = user.UserRoles.Where(userRole => userRole.StateId == StateIdConst.ACTIVE).
                                  SelectMany(userRole => userRole.Role.RoleModules
                                                .Select(roleModule => roleModule.Module.Code))
                                                .Distinct()                    
                });
    }
}
