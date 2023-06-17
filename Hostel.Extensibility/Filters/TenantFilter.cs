namespace Hostel.Extensibility.Filters;

public record TenantFilter : EntityFilterBase
{
    public IReadOnlyCollection<string> FirstName { get; init; }

    public IReadOnlyCollection<string> LastName { get; init; }

    public IReadOnlyCollection<string> Patronymic { get; init; }

    public IReadOnlyCollection<string> PhoneNumber { get; init; }

    public IReadOnlyCollection<string> Sex { get; init; }

    public IReadOnlyCollection<string> Role { get; init; }

    public IReadOnlyCollection<DateOnly> CheckInDate { get; init; }

    public IReadOnlyCollection<DateOnly> CheckOutDate { get; init; }

    public IReadOnlyCollection<int> HostelId { get; init; }

    public IReadOnlyCollection<int> RoomId { get; init; }
}