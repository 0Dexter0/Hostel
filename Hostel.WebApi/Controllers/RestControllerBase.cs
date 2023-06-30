using Hostel.Extensibility.Filters;
using Hostel.Extensibility.Models;
using Hostel.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hostel.WebApi.Controllers;

public abstract class RestControllerBase<TEntity, TEntityFilter> : ControllerBase
    where TEntity : EntityBase
    where TEntityFilter : EntityFilterBase
{
    private readonly ICrudServiceBase<TEntity, TEntityFilter> _crudService;

    protected RestControllerBase(ICrudServiceBase<TEntity, TEntityFilter> crudService)
    {
        _crudService = crudService;
    }

    [HttpPost("batch-filter")]
    public virtual IActionResult GetAll([FromBody]TEntityFilter filter) => new OkObjectResult(_crudService.GetAll(filter));

    [HttpPost]
    public virtual IActionResult Add(TEntity model)
    {
        var addResult = _crudService.Add(model, out _);

        return addResult.IsValid
            ? new CreatedResult(String.Empty, addResult)
            : new BadRequestObjectResult(addResult);
    }

    [HttpPut]
    public virtual IActionResult Update(TEntity model)
    {
        var updateResult = _crudService.Update(model);

        return updateResult.IsValid
            ? new OkObjectResult(updateResult)
            : new BadRequestObjectResult(updateResult);
    }

    [HttpDelete]
    public virtual IActionResult Delete(TEntity model)
    {
        var deleteResult = _crudService.Delete(model);

        return deleteResult.IsValid
            ? new OkObjectResult(deleteResult)
            : new BadRequestObjectResult(deleteResult);
    }
}