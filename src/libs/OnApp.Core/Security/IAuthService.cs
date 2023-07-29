using Global.Security;

namespace OnApp.Core.Security
{
    public interface IAuthService :
        ICookieJwtAuthService
    {
        public UserAuthModel User { get;}
        OrganizationAuthModel ParentOrganization { get; }
        OrganizationAuthModel Organization { get; }
        bool HasPermission();
        void ResetUserName(string userName);
        bool HasPermission(params ModuleCode[] moduleCodes);
    }
}
