using Global;

namespace OnApp.DataLayer.Repository;

public static class UserFilter
{
    /*public static IQueryable<User> ByUserName(this IQueryable<User> source,
                                              string userName,
                                              bool isIncludePassive = false)
    {
        if (userName.NullOrEmpty())
            throw new ArgumentException($"{nameof(userName)} cannot be null or empty string", nameof(userName));

        if (!isIncludePassive)
            source = source.IsActive();

        return source.Where(user => user.UserName.ToLower() == userName.ToLower());
    }*/

    public static IQueryable<User> ByEmail(this IQueryable<User> source,
                                           string email,
                                           bool isIncludePassive = true)
    {
        if (email.NullOrEmpty())
            throw new ArgumentException($"{nameof(email)} cannot be null or empty string", nameof(email));

        if (!isIncludePassive)
            source = source.IsActive();

        return source.Where(user => user.Email.ToLower() == email.ToLower());
    }

}
