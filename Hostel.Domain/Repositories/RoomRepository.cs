using Hostel.Domain.Context;
using Hostel.Extensibility.Converters;
using Hostel.Extensibility.Extensions;
using Hostel.Extensibility.Filters;
using Hostel.Extensibility.Models;

namespace Hostel.Domain.Repositories;

internal class RoomRepository : CrudRepositoryBase<Room, Models.Room, RoomFilter>, IRoomRepository
{
    public RoomRepository(HostelDbContext dbContext, IModelConverter<Room, Models.Room> modelConverter)
        : base(dbContext, dbContext.Rooms, modelConverter)
    {
    }

    protected override IQueryable<Models.Room> ApplyFilter(RoomFilter filter)
    {
        var query = Entities.AsQueryable();

        if (!filter.Id.IsNullOrEmpty())
        {
            query = query.Where(x => filter.Id.Contains(x.Id));
        }

        if (!filter.Number.IsNullOrEmpty())
        {
            query = query.Where(x => filter.Number.Contains(x.Number));
        }

        if (!filter.ForSex.IsNullOrEmpty())
        {
            query = query.Where(x => filter.ForSex.Contains(x.ForSex));
        }

        if (!filter.MaxPeople.IsNullOrEmpty())
        {
            query = query.Where(x => filter.MaxPeople.Contains(x.MaxPeople));
        }

        if (!filter.HostelId.IsNullOrEmpty())
        {
            query = query.Where(x => filter.HostelId.Contains(x.HostelId));
        }

        return query;
    }
}