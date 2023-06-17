using Hostel.Extensibility.Filters;
using Hostel.Service.Services;
using Hostel.WebApi.Routes;

namespace Hostel.WebApi.Controllers;

[RestRoute($"{CollectionName}")]
public class HostelController : RestControllerBase<Extensibility.Models.Hostel, HostelFilter>
{
    private const string CollectionName = "hostels";

    public HostelController(IHostelService crudService)
        : base(crudService)
    {
    }
}