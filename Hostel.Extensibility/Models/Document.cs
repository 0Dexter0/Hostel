namespace Hostel.Extensibility.Models;

public class Document : EntityBase
{
    public string Url { get; set; }

    public string DocumentType { get; set; }

    public int TenantId { get; set; }

    public virtual Tenant Tenant { get; set; }
}
