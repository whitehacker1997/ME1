using OnApp.BizLayer.ManualServices;
using OnApp.Core.Security;
using OnApp.DataLayer.Repository;
using GenericServices.Setup;
using NetCore.AutoRegisterDi;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class GenericServiceExtentions
    {
        public static void ConfigureGenericServices(this IServiceCollection services)
        {
            services.GenericServicesSimpleSetup<EfCoreContext>(
                Assembly.GetAssembly(typeof(IAuthService)), //Core
                Assembly.GetAssembly(typeof(ManualService)),//Service Layer
                Assembly.GetAssembly(typeof(EfCoreContext)) //Data layer Repository
            );

            services.RegisterAssemblyPublicNonGenericClasses(
                Assembly.GetAssembly(typeof(IAuthService)), //Core
                Assembly.GetAssembly(typeof(ManualService)),//Service Layer
                Assembly.GetAssembly(typeof(EfCoreContext)) //Data Layer Repository
            ).AsPublicImplementedInterfaces(ServiceLifetime.Scoped);
        }
    }
}
