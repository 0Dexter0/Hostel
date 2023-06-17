namespace Hostel.Extensibility.Models;

public record SecurityPersonal : EntityBase
{
    public string FirstName { get; init; }

    public string LastName { get; init; }

    public string Patronymic { get; init; }

    public string PhoneNumber { get; init; }

    public string Role { get; init; }

    public int HostelId { get; init; }
}
