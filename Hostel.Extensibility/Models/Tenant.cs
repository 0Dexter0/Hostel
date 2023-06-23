namespace Hostel.Extensibility.Models;

public record Tenant : EntityBase
{
    public string FirstName { get; init; }

    public string LastName { get; init; }

    public string Patronymic { get; init; }

    public string PhoneNumber { get; init; }

    public string Sex { get; init; }

    public string Role { get; init; }

    public DateOnly CheckInDate { get; init; }

    public DateOnly CheckOutDate { get; init; }

    public int HostelId { get; init; }

    public int RoomId { get; init; }
}
