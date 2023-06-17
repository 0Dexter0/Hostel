using Hostel.Extensibility.Filters;
using Hostel.Extensibility.Models;
using Hostel.Service.Services;
using Hostel.WebApi.Routes;

namespace Hostel.WebApi.Controllers;

[RestRoute($"{CollectionName}")]
public class TenantController : RestControllerBase<SecurityTenant, TenantFilter>
{
    private const string CollectionName = "tenants";

    public TenantController(ITenantService crudService)
        : base(crudService)
    {
    }
}