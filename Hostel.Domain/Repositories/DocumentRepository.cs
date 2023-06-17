using Hostel.Domain.Context;
using Hostel.Extensibility.Converters;
using Hostel.Extensibility.Extensions;
using Hostel.Extensibility.Filters;
using Hostel.Extensibility.Models;

namespace Hostel.Domain.Repositories;

internal class DocumentRepository : CrudRepositoryBase<Document, Models.Document, DocumentFilter>, IDocumentRepository
{
    public DocumentRepository(HostelDbContext dbContext, IModelConverter<Document, Models.Document> modelConverter)
        : base(dbContext, dbContext.Documents, modelConverter)
    {
    }

    protected override IQueryable<Models.Document> ApplyFilter(DocumentFilter filter)
    {
        var query = Entities.AsQueryable();

        if (!filter.Id.IsNullOrEmpty())
        {
            query = query.Where(x => filter.Id.Contains(x.Id));
        }

        if (!filter.DocumentType.IsNullOrEmpty())
        {
            query = query.Where(x => filter.DocumentType.Contains(x.DocumentType));
        }

        if (!filter.TenantId.IsNullOrEmpty())
        {
            query = query.Where(x => filter.TenantId.Contains(x.TenantId));
        }

        if (!filter.Url.IsNullOrEmpty())
        {
            query = query.Where(x => filter.Url.Contains(x.Url));
        }

        return query;
    }
}