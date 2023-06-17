using Hostel.Extensibility.Filters;
using Hostel.Extensibility.Models;
using Hostel.Service.Services;
using Hostel.WebApi.Routes;

namespace Hostel.WebApi.Controllers;

[RestRoute($"{CollectionName}")]
public class DocumentController : RestControllerBase<Document, DocumentFilter>
{
    private const string CollectionName = "documents";

    public DocumentController(IDocumentService crudService)
        : base(crudService)
    {
    }
}