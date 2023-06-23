using Hostel.Domain.Repositories;
using Hostel.Extensibility.Filters;
using Hostel.Extensibility.Models;

namespace Hostel.Service.Services;

internal class TenantService : CrudServiceBase<Tenant, TenantFilter>, ITenantService
{
    public TenantService(ITenantRepository repository)
        : base(repository)
    {
    }
}