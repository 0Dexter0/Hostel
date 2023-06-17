namespace Hostel.Extensibility.Models;

public record Document : EntityBase
{
    public string Url { get; init; }

    public string DocumentType { get; init; }

    public int TenantId { get; init; }
}
