using Hostel.Domain.Context;
using Hostel.Extensibility.Converters;
using Hostel.Extensibility.Extensions;
using Hostel.Extensibility.Filters;
using Hostel.Extensibility.Models;

namespace Hostel.Domain.Repositories;

internal class VisitRepository : CrudRepositoryBase<Visit, Models.Visit, VisitFilter>, IVisitRepository
{
    public VisitRepository(HostelDbContext dbContext, IModelConverter<Visit, Models.Visit> modelConverter)
        : base(dbContext, dbContext.Visits, modelConverter)
    {
    }

    protected override IQueryable<Models.Visit> ApplyFilter(VisitFilter filter)
    {
        var query = Entities.AsQueryable();

        if (!filter.Id.IsNullOrEmpty())
        {
            query = query.Where(x => filter.Id.Contains(x.Id));
        }

        if (!filter.Date.IsNullOrEmpty())
        {
            query = query.Where(x => filter.Date.Contains(x.Date));
        }

        if (!filter.PersonalId.IsNullOrEmpty())
        {
            query = query.Where(x => filter.PersonalId.Contains(x.PersonalId));
        }

        if (!filter.TenantId.IsNullOrEmpty())
        {
            query = query.Where(x => filter.TenantId.Contains(x.TenantId));
        }

        if (!filter.HostelId.IsNullOrEmpty())
        {
            query = query.Where(x => filter.HostelId.Contains(x.HostelId));
        }

        return query;
    }
}