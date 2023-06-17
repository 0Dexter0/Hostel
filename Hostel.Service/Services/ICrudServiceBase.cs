using Hostel.Extensibility.Filters;
using Hostel.Extensibility.Models;

namespace Hostel.Service.Services;

public interface ICrudServiceBase<TEntity, in TEntityFilter>
    where TEntity : EntityBase
    where TEntityFilter : EntityFilterBase
{
    IReadOnlyCollection<TEntity> GetAll(TEntityFilter filter);

    bool Add(TEntity model, out TEntity created);

    bool Update(TEntity model);

    bool Delete(TEntity model);
}