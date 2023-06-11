namespace Hostel.Extensibility.Models;

public class Room : EntityBase
{
    public string Number { get; set; }

    public int MaxPeople { get; set; }

    public string ForSex { get; set; }

    public int HostelId { get; set; }
}
