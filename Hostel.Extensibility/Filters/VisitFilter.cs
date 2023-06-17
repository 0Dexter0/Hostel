namespace Hostel.Extensibility.Filters;

public record VisitFilter : EntityFilterBase
{
    public IReadOnlyCollection<DateOnly> Date { get; init; }

    public IReadOnlyCollection<int> TenantId { get; init; }

    public IReadOnlyCollection<int> PersonalId { get; init; }

    public IReadOnlyCollection<int> HostelId { get; init; }
}