using Hostel.Extensibility.Converters;
using Hostel.Service.Converters;
using Hostel.Service.Services;
using Microsoft.DependencyInjection.Module.InjectionModules;
using Microsoft.Extensions.DependencyInjection;

namespace Hostel.Service.InjectionModules;

public class HostelServiceInjectionModule : InjectionModuleBase
{
    public override void Load(IServiceCollection services)
    {
        services.AddTransient(typeof(IModelConverter<,>), typeof(ModelConverter<,>));

        services.AddTransient<IHostelService, HostelService>();
        services.AddTransient<ITenantService, TenantService>();
        services.AddTransient<ISecurityPersonalService, SecurityPersonalService>();
        services.AddTransient<IDocumentService, DocumentService>();
        services.AddTransient<IRoomService, RoomService>();
        services.AddTransient<IVisitService, VisitService>();
        services.AddTransient<IAuthPersonalService, AuthPersonalService>();

        services.AddScoped<ICurrentUserProvider, CurrentUserProvider>();
    }
}