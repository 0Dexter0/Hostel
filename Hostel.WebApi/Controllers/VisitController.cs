using Hostel.Extensibility.Filters;
using Hostel.Extensibility.Models;
using Hostel.Service.Services;
using Hostel.WebApi.Routes;

namespace Hostel.WebApi.Controllers;

[RestRoute($"{CollectionName}")]
public class VisitController : RestControllerBase<Visit, VisitFilter>
{
    private const string CollectionName = "visits";

    public VisitController(IVisitService crudService)
        : base(crudService)
    {
    }
}