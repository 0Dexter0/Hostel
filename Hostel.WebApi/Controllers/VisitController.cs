using Hostel.Auth;
using Hostel.Extensibility.Filters;
using Hostel.Extensibility.Models;
using Hostel.Service.Services;
using Hostel.WebApi.Routes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hostel.WebApi.Controllers;

[RestRoute($"{CollectionName}")]
public class VisitController : RestControllerBase<Visit, VisitFilter>
{
    private const string CollectionName = "visits";

    public VisitController(IVisitService crudService)
        : base(crudService)
    {
    }

    [Authorize(Policies.Watchman)]
    public override IActionResult GetAll(VisitFilter filter) => base.GetAll(filter);

    [Authorize(Policies.Watchman)]
    public override IActionResult Add(Visit model) => base.Add(model);

    [Authorize(Policies.Watchman)]
    public override IActionResult Update(Visit model) => base.Update(model);

    [Authorize(Policies.Commandant)]
    public override IActionResult Delete(Visit model) => base.Delete(model);
}