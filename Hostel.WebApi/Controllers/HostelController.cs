using Hostel.Auth;
using Hostel.Extensibility.Filters;
using Hostel.Service.Services;
using Hostel.WebApi.Routes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hostel.WebApi.Controllers;

[RestRoute($"{CollectionName}")]
public class HostelController : RestControllerBase<Extensibility.Models.Hostel, HostelFilter>
{
    private const string CollectionName = "hostels";

    public HostelController(IHostelService crudService)
        : base(crudService)
    {
    }

    [Authorize(Policies.Watchman)]
    public override IActionResult GetAll(HostelFilter filter) => base.GetAll(filter);
}