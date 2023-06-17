using Hostel.Domain.Repositories;
using Hostel.Extensibility.Filters;
using Hostel.Extensibility.Models;

namespace Hostel.Service.Services;

internal class DocumentService : CrudServiceBase<Document, DocumentFilter>, IDocumentService
{
    public DocumentService(IDocumentRepository repository)
        : base(repository)
    {
    }
}