using Hostel.Extensibility.Filters;
using Hostel.Extensibility.Models;
using Hostel.Service.Services;
using Hostel.WebApi.Routes;

namespace Hostel.WebApi.Controllers;

[RestRoute($"{CollectionName}")]
public class RoomController : RestControllerBase<Room, RoomFilter>
{
    private const string CollectionName = "rooms";

    public RoomController(IRoomService crudService)
        : base(crudService)
    {
    }
}