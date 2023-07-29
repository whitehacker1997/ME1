using OnApp.Core.Security;
using Global.DependencyIncection;
using Microsoft.EntityFrameworkCore;

namespace OnApp.Core
{
    public class ServiceProvider 
        : BaseServiceProvider<IAuthService>
    {
        public static DbContext Context { get => GetService<DbContext>(); }
    }
}
