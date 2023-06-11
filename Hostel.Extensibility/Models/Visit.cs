namespace Hostel.Extensibility.Models;

public class Visit : EntityBase
{
    public DateOnly Date { get; set; }

    public string Description { get; set; }

    public int TenantId { get; set; }

    public int PersonalId { get; set; }

    public int HostelId { get; set; }
}
