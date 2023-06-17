using Hostel.Domain.Repositories;
using Hostel.Extensibility.Filters;
using Hostel.Extensibility.Models;

namespace Hostel.Service.Services;

internal class RoomService : CrudServiceBase<Room, RoomFilter>, IRoomService
{
    public RoomService(IRoomRepository repository)
        : base(repository)
    {
    }
}