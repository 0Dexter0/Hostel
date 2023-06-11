namespace Hostel.Extensibility.Models;

public class Tenant : EntityBase
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Patronymic { get; set; }

    public string PhoneNumber { get; set; }

    public string Sex { get; set; }

    public string Role { get; set; }

    public string Password { get; set; }

    public DateOnly CheckInDate { get; set; }

    public DateOnly CheckOutDate { get; set; }

    public int HostelId { get; set; }

    public int RoomId { get; set; }
}
