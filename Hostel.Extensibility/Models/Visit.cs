namespace Hostel.Extensibility.Models;

public record Visit : EntityBase
{
    public DateOnly Date { get; init; }

    public string Description { get; init; }

    public int TenantId { get; init; }

    public int PersonalId { get; init; }

    public int HostelId { get; init; }
}
