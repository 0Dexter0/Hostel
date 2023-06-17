using Hostel.Domain.Repositories;
using Microsoft.DependencyInjection.Module.InjectionModules;
using Microsoft.Extensions.DependencyInjection;

namespace Hostel.Domain.InjectionModules;

public class HostelDomainInjectionModule : InjectionModuleBase
{
    public override void Load(IServiceCollection services)
    {
        services.AddTransient<IHostelRepository, HostelRepository>();
        services.AddTransient<ITenantRepository, TenantRepository>();
        services.AddTransient<IPersonalRepository, PersonalRepository>();
        services.AddTransient<IDocumentRepository, DocumentRepository>();
        services.AddTransient<IRoomRepository, RoomRepository>();
        services.AddTransient<IVisitRepository, VisitRepository>();
    }
}