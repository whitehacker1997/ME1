using OnApp.DataLayer.Repository;
using Global;

namespace OnApp.BizLayer
{
    public static class UserFilter
    {
        public static IQueryable<User> ByUserName(this IQueryable<User> users,
                                                  string userName,
                                                  bool isIncludePassive = false)
        {
            if (userName.NullOrEmpty())
                throw new ArgumentException(message: $"{nameof(userName)} cannot be null or empty string",
                                            paramName: nameof(userName));

            if (!isIncludePassive)
                users = users.IsActive();

            return users.Where(a => a.UserName.ToLower() == userName.ToLower());
        }

        public static IQueryable<User> ByEmail(this IQueryable<User> users,
                                                  string email,
                                                  bool isIncludePassive = false)
        {
            if (email.NullOrEmpty())
                throw new ArgumentException(message: $"{nameof(email)} cannot be null or empty string",
                                            paramName: nameof(email));

            if (!isIncludePassive)
                users = users.IsActive();

            return users.Where(a => a.Email.ToLower() == email.ToLower());
        }
    }
}
