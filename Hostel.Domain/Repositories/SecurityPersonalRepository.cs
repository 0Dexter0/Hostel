using Hostel.Domain.Context;
using Hostel.Extensibility.Converters;
using Hostel.Extensibility.Extensions;
using Hostel.Extensibility.Filters;
using Hostel.Extensibility.Models;
using Personal = Hostel.Domain.Models.Personal;

namespace Hostel.Domain.Repositories;

internal class SecurityPersonalRepository : CrudRepositoryBase<SecurityPersonal, Personal, PersonalFilter>, ISecurityPersonalRepository
{
    public SecurityPersonalRepository(HostelDbContext dbContext, IModelConverter<SecurityPersonal, Personal> modelConverter)
        : base(dbContext, dbContext.Personals, modelConverter)
    {
    }

    protected override IQueryable<Personal> ApplyFilter(PersonalFilter filter)
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

        if (!filter.PhoneNumber.IsNullOrEmpty())
        {
            query = query.Where(x => filter.PhoneNumber.Contains(x.PhoneNumber));
        }

        if (!filter.HostelId.IsNullOrEmpty())
        {
            query = query.Where(x => filter.HostelId.Contains(x.HostelId));
        }

        return query;
    }
}