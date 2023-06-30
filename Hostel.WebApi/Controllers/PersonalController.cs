using Hostel.Auth;
using Hostel.Extensibility.Filters;
using Hostel.Extensibility.Models;
using Hostel.Service.Services;
using Hostel.WebApi.Routes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hostel.WebApi.Controllers;

[RestRoute($"{CollectionName}")]
public class PersonalController : RestControllerBase<SecurityPersonal, PersonalFilter>
{
    private const string CollectionName = "personal";

    public PersonalController(ISecurityPersonalService crudService)
        : base(crudService)
    {
    }

    [Authorize(Policies.Commandant)]
    public override IActionResult GetAll(PersonalFilter filter) => base.GetAll(filter);

    [Authorize(Policies.Admin)]
    public override IActionResult Add(SecurityPersonal model) => base.Add(model);

    [Authorize(Policies.Admin)]
    public override IActionResult Update(SecurityPersonal model) => base.Update(model);

    [Authorize(Policies.Admin)]
    public override IActionResult Delete(SecurityPersonal model) => base.Delete(model);
}