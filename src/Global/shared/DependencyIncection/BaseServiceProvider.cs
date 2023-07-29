using Global.Helpers;
using Global.Security;
using Global.Storage;

namespace Global.DependencyIncection
{
    public class BaseServiceProvider
    {
        private static Func<IServiceProvider> _serviceProviderAccessor;
        public static void Initialize(Func<IServiceProvider> serviceProviderAccessor) 
            => _serviceProviderAccessor = serviceProviderAccessor;

        protected static TService GetService<TService>() 
            => (TService)GetService(typeof(TService));

        protected static object GetService(Type serviceType) 
            => _serviceProviderAccessor().GetService(serviceType);
    }
    public class BaseServiceProvider<TAuthService> :
        BaseServiceProvider 
        where TAuthService : IAuthService
    {
        public static TAuthService AuthService 
            => GetService<TAuthService>();

        public static IStorageService StorageService 
            => GetService<IStorageService>();

        public static ICultureHelper CultureHelper 
            => GetService<ICultureHelper>();
    }
}
