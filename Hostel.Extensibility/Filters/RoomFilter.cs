namespace Hostel.Extensibility.Filters;

public record RoomFilter : EntityFilterBase
{
    public IReadOnlyCollection<string> Number { get; init; }

    public IReadOnlyCollection<int> MaxPeople { get; init; }

    public IReadOnlyCollection<string> ForSex { get; init; }

    public IReadOnlyCollection<int> HostelId { get; init; }
}