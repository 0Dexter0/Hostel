namespace Hostel.Extensibility.Models;

public record Room : EntityBase
{
    public string Number { get; init; }

    public int MaxPeople { get; init; }

    public string ForSex { get; init; }

    public int HostelId { get; init; }
}
