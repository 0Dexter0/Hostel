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
    public virtual IActionResult Add(TEntity model) =>
        _crudService.Add(model, out var created)
            ? new CreatedResult(String.Empty, created)
            : new BadRequestResult();

    [HttpPut]
    public virtual IActionResult Update(TEntity model) =>
        _crudService.Update(model)
            ? new OkResult()
            : new BadRequestResult();

    [HttpDelete]
    public virtual IActionResult Delete(TEntity model) =>
        _crudService.Delete(model)
            ? new OkResult()
            : new BadRequestResult();
}