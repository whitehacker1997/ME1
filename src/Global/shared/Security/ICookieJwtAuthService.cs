namespace Global.Security
{
    public interface ICookieJwtAuthService : 
        IAuthService
    {
        string Login(string userName);
        void Logout();
    }
}
