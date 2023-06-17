using Hostel.Domain.Context;
using Hostel.Extensibility.Converters;
using Hostel.Extensibility.Extensions;
using Hostel.Extensibility.Filters;
using Hostel.Extensibility.Models;

namespace Hostel.Domain.Repositories;

public class TenantRepository : CrudRepositoryBase<SecurityTenant, Models.Tenant, TenantFilter>, ITenantRepository
{
    public TenantRepository(HostelDbContext dbContext, IModelConverter<SecurityTenant, Models.Tenant> modelConverter)
        : base(dbContext, dbContext.Tenants, modelConverter)
    {
    }

    protected override IQueryable<Models.Tenant> ApplyFilter(TenantFilter filter)
    {
        var query = Entities.AsQueryable();

        if (!filter.Id.IsNullOrEmpty())
        {
            query = query.Where(x => filter.Id.Contains(x.Id));
        }

        if (!filter.FirstName.IsNullOrEmpty())
        {
            query = query.Where(x => filter.FirstName.Contains(x.FirstName));
        }

        if (!filter.LastName.IsNullOrEmpty())
        {
            query = query.Where(x => filter.LastName.Contains(x.LastName));
        }

        if (!filter.Patronymic.IsNullOrEmpty())
        {
            query = query.Where(x => filter.Patronymic.Contains(x.Patronymic));
        }

        if (!filter.Role.IsNullOrEmpty())
        {
            query = query.Where(x => filter.Role.Contains(x.Role));
        }

        if (!filter.Sex.IsNullOrEmpty())
        {
            query = query.Where(x => filter.Sex.Contains(x.Sex));
        }

        if (!filter.PhoneNumber.IsNullOrEmpty())
        {
            query = query.Where(x => filter.PhoneNumber.Contains(x.PhoneNumber));
        }

        if (!filter.RoomId.IsNullOrEmpty())
        {
            query = query.Where(x => filter.RoomId.Contains(x.RoomId));
        }

        if (!filter.HostelId.IsNullOrEmpty())
        {
            query = query.Where(x => filter.HostelId.Contains(x.HostelId));
        }

        if (!filter.CheckInDate.IsNullOrEmpty())
        {
            query = query.Where(x => filter.CheckInDate.Contains(x.CheckInDate));
        }

        if (!filter.CheckOutDate.IsNullOrEmpty())
        {
            query = query.Where(x => filter.CheckOutDate.Contains(x.CheckOutDate));
        }

        return query;
    }
}