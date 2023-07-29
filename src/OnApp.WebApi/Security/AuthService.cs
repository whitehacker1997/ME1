using OnApp.BizLayer;
using OnApp.BizLayer.AccountServices;
using OnApp.Core.Security;
using OnApp.DataLayer.Repository;
using Global.EF;
using Global.Security;
using Microsoft.EntityFrameworkCore;

using IAuthService = OnApp.Core.Security.IAuthService;

namespace OnApp.WebApi.Security
{
    public class AuthService : 
        JwtAuthService,
        IAuthService
    {
        private DbContext _context;
        public AuthService(
            IHttpContextAccessor httpContextAccessor,
            DbContext context,
            JwtConfig jwtConfig
            ) :
            base(config: jwtConfig,
                     httpContextAccessor: httpContextAccessor)
        {
            _context = context;
            ((BaseDbContext)_context).SetAuthService(this);
        }

        private UserAuthModel _user;
        public UserAuthModel User
        {
            get
            {
                if (IsAuthenticated)
                {
                    _user = _context.Set<User>()
                                .Include(user => user.Person)
                                .ByUserName(UserName)
                                .MapToAuthModel()
                                .FirstOrDefault();

                    _user?.ResolveModules();
                }

                return _user;
            }
        }


        private OrganizationAuthModel _organization;
        public OrganizationAuthModel Organization
        {
            get
            {
                if (IsAuthenticated && _organization == null)
                    _organization = _context.Set<Organization>()
                        .Where(a => a.Id == User.OrganizationId)
                            .MapToAuthModel()
                                .FirstOrDefault();

                return _organization;
            }
        }

        private OrganizationAuthModel _parentOrganization;
        public OrganizationAuthModel ParentOrganization
        {
            get
            {
                if (IsAuthenticated && _parentOrganization == null && Organization.ParentId.HasValue)
                    _parentOrganization = _context.Set<Organization>()
                        .Where(a => a.Id == Organization.ParentId)
                            .MapToAuthModel()
                                .FirstOrDefault();

                return _parentOrganization;
            }
        }


        private int? _userId;
        public override object UserId
        {
            get 
            {
                if (_userId.HasValue)
                    return _userId;

                if (IsAuthenticated)
                    _userId = User.Id;

                return _userId;
            }
        }


        private HashSet<string> _modules;
        public override HashSet<string> Modules
        {
            get
            {
                if (IsAuthenticated && _modules == null)
                    _modules = User.Modules.ToHashSet();
                return _modules;
            }
        }

        public bool HasPermission(params ModuleCode[] moduleCodes)
            => moduleCodes.Any(moduleCode => HasPermission(moduleCode.ToString()));

        public string Login(string userName)
            => throw new NotImplementedException();

        public void Logout()
            => throw new NotImplementedException();

        public bool HasPermission()
            => throw new NotImplementedException();
    }
}
