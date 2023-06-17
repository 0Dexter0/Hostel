namespace Hostel.Extensibility.Filters;

public record PersonalFilter : EntityFilterBase
{
    public IReadOnlyCollection<string> FirstName { get; init; }

    public IReadOnlyCollection<string> LastName { get; init; }

    public IReadOnlyCollection<string> Patronymic { get; init; }

    public IReadOnlyCollection<string> PhoneNumber { get; init; }

    public IReadOnlyCollection<string> Role { get; init; }

    public IReadOnlyCollection<int> HostelId { get; init; }
}