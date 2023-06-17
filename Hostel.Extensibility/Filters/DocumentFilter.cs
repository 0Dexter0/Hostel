namespace Hostel.Extensibility.Filters;

public record DocumentFilter : EntityFilterBase
{
    public IReadOnlyCollection<string> Url { get; init; }

    public IReadOnlyCollection<string> DocumentType { get; init; }

    public IReadOnlyCollection<int> TenantId { get; init; }
}