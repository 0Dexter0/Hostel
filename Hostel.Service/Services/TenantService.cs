using Hostel.Domain.Repositories;
using Hostel.Extensibility.Filters;
using Hostel.Extensibility.Models;

namespace Hostel.Service.Services;

public class TenantService : CrudServiceBase<SecurityTenant, TenantFilter>, ITenantService
{
    public TenantService(ITenantRepository repository)
        : base(repository)
    {
    }
}