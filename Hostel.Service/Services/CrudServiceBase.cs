using Hostel.Domain.Models.Response;
using Hostel.Domain.Repositories;
using Hostel.Extensibility.Filters;
using Hostel.Extensibility.Models;

namespace Hostel.Service.Services;

internal abstract class CrudServiceBase<TEntity, TEntityFilter> : ICrudServiceBase<TEntity, TEntityFilter>
    where TEntity : EntityBase
    where TEntityFilter : EntityFilterBase
{
    private readonly ICrudRepositoryBase<TEntity, TEntityFilter> _repository;

    protected CrudServiceBase(ICrudRepositoryBase<TEntity, TEntityFilter> repository)
    {
        _repository = repository;
    }

    public OperationResponse<IReadOnlyCollection<TEntity>> GetAll(TEntityFilter filter) => new(_repository.GetAll(filter));

    public OperationResponse<TEntity> Add(TEntity model, out TEntity created) =>
        _repository.Add(model, out created)
        ? new(created)
        : new(MessageLevel.Error, $"Can't add current {model.GetType().Name}.");

    public OperationResponse Update(TEntity model) =>
        _repository.Update(model)
            ? new()
            : new(MessageLevel.Error, $"Can't update current {model.GetType().Name}.");

    public OperationResponse Delete(TEntity model) =>
        _repository.Delete(model)
            ? new()
            : new(MessageLevel.Error, $"Can't delete current {model.GetType().Name}.");
}