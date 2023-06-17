namespace Hostel.Extensibility.Filters;

public record HostelFilter : EntityFilterBase
{
    public IReadOnlyCollection<string> Address { get; init; }

    public IReadOnlyCollection<int> Number { get; init; }
}