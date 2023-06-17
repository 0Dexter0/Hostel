using Hostel.Domain.Context;
using Microsoft.DependencyInjection.Module.InjectionModules;
using Microsoft.DependencyInjection.Module.Loaders;
using Microsoft.EntityFrameworkCore;

namespace Hostel.WebApi.InjectionModules;

public class HostelWebApiInjectionModule : InjectionModuleBase
{
    public override void Load(IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddDbContext<HostelDbContext>(
            opt =>
                opt.UseNpgsql("Host=localhost;Port=5000;Username=dexter;Password=1410;Database=Hostel;"));
        // opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
        services.AddAutoMapper(
            AssemblyLoader.LoadAssemblies()
                .Where(x => x.FullName!.StartsWith("Hostel")));
    }
}