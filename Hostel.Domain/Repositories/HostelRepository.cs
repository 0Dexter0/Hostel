using Hostel.Domain.Context;
using Hostel.Extensibility.Converters;
using Hostel.Extensibility.Filters;

namespace Hostel.Domain.Repositories;

public class HostelRepository : CrudRepositoryBase<Extensibility.Models.Hostel, Models.Hostel, HostelFilter>, IHostelRepository
{
    public HostelRepository(
        HostelDbContext dbContext, IModelConverter<Extensibility.Models.Hostel, Models.Hostel> modelConverter)
        : base(dbContext, dbContext.Hostels, modelConverter)
    {
    }

    protected override IQueryable<Models.Hostel> ApplyFilter(HostelFilter filter)
    {
        var query = Entities.AsQueryable();

        if (CanApplyFilter(filter.Id))
        {
            query = query.Where(x => filter.Id.Contains(x.Id));
        }

        if (CanApplyFilter(filter.Number))
        {
            query = query.Where(x => filter.Number.Contains(x.Number));
        }

        if (CanApplyFilter(filter.Address))
        {
            query = query.Where(x => filter.Address.Contains(x.Address));
        }

        return query;
    }
}