using Hostel.Extensibility.Filters;
using Hostel.Extensibility.Models;
using Hostel.Service.Services;
using Hostel.WebApi.Routes;

namespace Hostel.WebApi.Controllers;

[RestRoute($"{CollectionName}")]
public class PersonalController : RestControllerBase<SecurityPersonal, PersonalFilter>
{
    private const string CollectionName = "personal";

    public PersonalController(ISecurityPersonalService crudService)
        : base(crudService)
    {
    }
}