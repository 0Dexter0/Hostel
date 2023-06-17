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
        services.AddTransient<IPersonalService, PersonalService>();
        services.AddTransient<IDocumentService, DocumentService>();
    }
}