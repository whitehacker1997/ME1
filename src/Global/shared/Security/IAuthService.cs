namespace Global.Security
{
    public interface IAuthService
    {
        string UserIp { get; }
        string UserAgent { get; }
        object UserId { get; }
        string UserName { get; }
        bool IsAuthenticated { get; }
        HashSet<string> Modules { get; }
        bool HasPermission(string moduleCode);
        string GenerateToken(string userName);
    }
}
