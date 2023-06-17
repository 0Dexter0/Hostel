namespace Hostel.Extensibility.Models;

public record Hostel : EntityBase
{
    public string Address { get; init; }

    public int Number { get; init; }

    public string Description { get; init; }
}
