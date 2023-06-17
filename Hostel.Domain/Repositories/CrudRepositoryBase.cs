using Hostel.Domain.Context;
using Hostel.Extensibility.Converters;
using Hostel.Extensibility.Extensions;
using Hostel.Extensibility.Filters;
using Hostel.Extensibility.Models;
using Microsoft.EntityFrameworkCore;

namespace Hostel.Domain.Repositories;

public abstract class CrudRepositoryBase<TServiceEntity, TDomainEntity, TEntityFilter>
    : ICrudRepositoryBase<TServiceEntity, TEntityFilter>
    where TServiceEntity : EntityBase
    where TDomainEntity : Models.EntityBase
    where TEntityFilter : EntityFilterBase
{
    private readonly IModelConverter<TServiceEntity, TDomainEntity> _modelConverter;
    protected HostelDbContext DbContext { get; }

    protected DbSet<TDomainEntity> Entities { get; }

    protected CrudRepositoryBase(
        HostelDbContext dbContext,
        DbSet<TDomainEntity> entities,
        IModelConverter<TServiceEntity, TDomainEntity> modelConverter)
    {
        DbContext = dbContext;
        Entities = entities;
        _modelConverter = modelConverter;
    }

    public IReadOnlyCollection<TServiceEntity> GetAll(TEntityFilter filter) =>
        ApplyFilter(filter).AsEnumerable().Select(_modelConverter.ToServiceModel).ToList();

    public virtual bool Add(TServiceEntity model, out TServiceEntity created)
    {
        var result = Entities.Add(_modelConverter.ToDomainModel(model));
        DbContext.SaveChanges();
        created = _modelConverter.ToServiceModel(result.Entity);

        return result.State is EntityState.Added;
    }

    public virtual bool Update(TServiceEntity model)
    {
        var origin = Entities.Find(model.Id);
        DbContext.SaveChanges();
        var result = Entities.Update(_modelConverter.ToDomainModel(model, origin));

        return result.State is EntityState.Modified;
    }

    public virtual bool Delete(TServiceEntity model)
    {
        var result = Entities.Remove(_modelConverter.ToDomainModel(model));
        DbContext.SaveChanges();

        return result.State is EntityState.Deleted;
    }

    protected bool CanApplyFilter<T>(IReadOnlyCollection<T> filterField) => filterField.IsNullOrEmpty();

    protected abstract IQueryable<TDomainEntity> ApplyFilter(TEntityFilter filter);
}