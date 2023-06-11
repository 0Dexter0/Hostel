using Hostel.Extensibility.Converters;
using Hostel.Extensibility.Extensions;
using Hostel.Extensibility.Filters;
using Hostel.Extensibility.Models;
using Microsoft.EntityFrameworkCore;

namespace Hostel.Domain.Repositories;

internal abstract class CrudRepositoryBase<TServiceEntity, TDomainEntity, TEntityFilter>
    : ICrudRepositoryBase<TServiceEntity, TEntityFilter>
    where TServiceEntity : EntityBase
    where TDomainEntity : Models.EntityBase
    where TEntityFilter : EntityFilterBase
{
    private readonly IModelConverter<TServiceEntity, TDomainEntity> _modelConverter;
    protected DbContext DbContext { get; }

    protected DbSet<TDomainEntity> Entities { get; }

    protected CrudRepositoryBase(
        DbContext dbContext,
        DbSet<TDomainEntity> entities,
        IModelConverter<TServiceEntity, TDomainEntity> modelConverter)
    {
        DbContext = dbContext;
        Entities = entities;
        _modelConverter = modelConverter;
    }

    public IReadOnlyCollection<TServiceEntity> GetAll(TEntityFilter filter) =>
        ApplyFilter(filter).AsEnumerable().Select(_modelConverter.ToServiceModel).ToList();

    public bool Add(TServiceEntity model, out TServiceEntity created)
    {
        var result = Entities.Add(_modelConverter.ToDomainModel(model));
        created = _modelConverter.ToServiceModel(result.Entity);

        return result.State is EntityState.Added;
    }

    public bool Update(TServiceEntity model)
    {
        throw new NotImplementedException();
    }

    public bool Delete(TServiceEntity model)
    {
        throw new NotImplementedException();
    }

    protected bool CanApplyFilter<T>(IReadOnlyCollection<T> filterField) => filterField.IsNullOrEmpty();

    protected abstract IQueryable<TDomainEntity> ApplyFilter(TEntityFilter filter);
}