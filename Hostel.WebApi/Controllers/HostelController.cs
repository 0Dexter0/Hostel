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

    [Authorize(Policies.Commandant)]
    public override IActionResult GetAll(HostelFilter filter) => base.GetAll(filter);

    [Authorize(Policies.Admin)]
    public override IActionResult Add(Extensibility.Models.Hostel model) => base.Add(model);

    [Authorize(Policies.Admin)]
    public override IActionResult Update(Extensibility.Models.Hostel model) => base.Update(model);

    [Authorize(Policies.Admin)]
    public override IActionResult Delete(Extensibility.Models.Hostel model) => base.Delete(model);
}