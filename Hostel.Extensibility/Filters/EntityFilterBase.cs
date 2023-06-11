namespace Hostel.Extensibility.Filters;

public record EntityFilterBase
{
    public IReadOnlyCollection<int> Id { get; init; }
}