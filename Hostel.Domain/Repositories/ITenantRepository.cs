using Hostel.Extensibility.Filters;
using Hostel.Extensibility.Models;

namespace Hostel.Domain.Repositories;

public interface ITenantRepository : ICrudRepositoryBase<Tenant, TenantFilter>
{
}