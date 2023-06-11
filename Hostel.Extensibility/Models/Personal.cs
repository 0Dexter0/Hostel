namespace Hostel.Extensibility.Models;

public class Personal : EntityBase
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Patronymic { get; set; }

    public string PhoneNumber { get; set; }

    public string Role { get; set; }

    public string Password { get; set; }

    public int HostelId { get; set; }
}
