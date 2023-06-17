using Hostel.Domain.Repositories;
using Hostel.Extensibility.Filters;
using Hostel.Extensibility.Models;

namespace Hostel.Service.Services;

public abstract class CrudServiceBase<TEntity, TEntityFilter> : ICrudServiceBase<TEntity, TEntityFilter>
    where TEntity : EntityBase
    where TEntityFilter : EntityFilterBase
{
    private readonly ICrudRepositoryBase<TEntity, TEntityFilter> _repository;

    protected CrudServiceBase(ICrudRepositoryBase<TEntity, TEntityFilter> repository)
    {
        _repository = repository;
    }

    public IReadOnlyCollection<TEntity> GetAll(TEntityFilter filter) => _repository.GetAll(filter);

    public bool Add(TEntity model, out TEntity created) => _repository.Add(model, out created);

    public bool Update(TEntity model) => _repository.Update(model);

    public bool Delete(TEntity model) => _repository.Delete(model);
}