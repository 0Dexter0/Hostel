using Hostel.Auth;
using Hostel.Domain.Context;
using Microsoft.DependencyInjection.Module.InjectionModules;
using Microsoft.DependencyInjection.Module.Loaders;
using Microsoft.EntityFrameworkCore;

namespace Hostel.WebApi.InjectionModules;

public class HostelWebApiInjectionModule : InjectionModuleBase
{
    public override void Load(IServiceCollection services)
    {
        services.AddAuthorization(
            opt =>
            {
                opt.AddPolicy(Policies.Admin, x => x.RequireRole(Roles.Admin));
                opt.AddPolicy(Policies.Commandant, x => x.RequireRole(Roles.Commandant, Roles.Admin));
                opt.AddPolicy(Policies.Watchman, x => x.RequireRole(Roles.Watchman, Roles.Commandant, Roles.Admin));
            });
        services.AddControllers();
        services.AddEndpointsApiExplorer();

        services.AddDbContext<HostelDbContext>(
            opt =>
                opt.UseNpgsql("Host=localhost;Port=5000;Username=dexter;Password=1410;Database=HostelApp;"));
        // opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
        services.AddAutoMapper(
            AssemblyLoader.LoadAssemblies()
                .Where(x => x.FullName!.StartsWith("Hostel")));
    }
}