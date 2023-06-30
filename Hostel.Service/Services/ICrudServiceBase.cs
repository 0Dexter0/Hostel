using Hostel.Domain.Models.Response;
using Hostel.Extensibility.Filters;
using Hostel.Extensibility.Models;

namespace Hostel.Service.Services;

public interface ICrudServiceBase<TEntity, in TEntityFilter>
    where TEntity : EntityBase
    where TEntityFilter : EntityFilterBase
{
    OperationResponse<IReadOnlyCollection<TEntity>> GetAll(TEntityFilter filter);

    OperationResponse<TEntity> Add(TEntity model, out TEntity created);

    OperationResponse Update(TEntity model);

    OperationResponse Delete(TEntity model);
}