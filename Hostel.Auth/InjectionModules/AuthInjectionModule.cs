using Hostel.Auth.Resolvers;
using Hostel.Auth.Services;
using Microsoft.DependencyInjection.Module.InjectionModules;
using Microsoft.Extensions.DependencyInjection;

namespace Hostel.Auth.InjectionModules;

public class AuthInjectionModule : InjectionModuleBase
{
    public override void Load(IServiceCollection services)
    {
        services.AddTransient<IRegistrationService, RegistrationService>();
        services.AddTransient<ILoginService, LoginService>();

        services.AddTransient<IRoleResolver, RoleResolver>();
    }
}