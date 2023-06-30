using Hostel.Auth;
using Hostel.Extensibility.Filters;
using Hostel.Extensibility.Models;
using Hostel.Service.Services;
using Hostel.WebApi.Routes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hostel.WebApi.Controllers;

[RestRoute($"{CollectionName}")]
public class DocumentController : RestControllerBase<Document, DocumentFilter>
{
    private const string CollectionName = "documents";

    public DocumentController(IDocumentService crudService)
        : base(crudService)
    {
    }

    [Authorize(Policies.Commandant)]
    public override IActionResult GetAll(DocumentFilter filter) => base.GetAll(filter);

    [Authorize(Policies.Commandant)]
    public override IActionResult Add(Document model) => base.Add(model);

    [Authorize(Policies.Commandant)]
    public override IActionResult Update(Document model) => base.Update(model);

    [Authorize(Policies.Commandant)]
    public override IActionResult Delete(Document model) => base.Delete(model);
}