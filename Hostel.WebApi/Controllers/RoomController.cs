using Hostel.Auth;
using Hostel.Extensibility.Filters;
using Hostel.Extensibility.Models;
using Hostel.Service.Services;
using Hostel.WebApi.Routes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hostel.WebApi.Controllers;

[RestRoute($"{CollectionName}")]
public class RoomController : RestControllerBase<Room, RoomFilter>
{
    private const string CollectionName = "rooms";

    public RoomController(IRoomService crudService)
        : base(crudService)
    {
    }

    [Authorize(Policies.Admin)]
    public override IActionResult GetAll(RoomFilter filter) => base.GetAll(filter);

    [Authorize(Policies.Admin)]
    public override IActionResult Add(Room model) => base.Add(model);

    [Authorize(Policies.Admin)]
    public override IActionResult Update(Room model) => base.Update(model);

    [Authorize(Policies.Admin)]
    public override IActionResult Delete(Room model) => base.Delete(model);
}