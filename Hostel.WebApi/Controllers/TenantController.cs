using Hostel.Auth;
using Hostel.Extensibility.Filters;
using Hostel.Extensibility.Models;
using Hostel.Service.Services;
using Hostel.WebApi.Routes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hostel.WebApi.Controllers;

[RestRoute($"{CollectionName}")]
public class TenantController : RestControllerBase<Tenant, TenantFilter>
{
    private const string CollectionName = "tenants";

    public TenantController(ITenantService crudService)
        : base(crudService)
    {
    }

    [Authorize(Policies.Watchman)]
    public override IActionResult GetAll(TenantFilter filter) => base.GetAll(filter);

    [Authorize(Policies.Commandant)]
    public override IActionResult Add(Tenant model) => base.Add(model);

    [Authorize(Policies.Commandant)]
    public override IActionResult Update(Tenant model) => base.Update(model);

    [Authorize(Policies.Commandant)]
    public override IActionResult Delete(Tenant model) => base.Delete(model);
}