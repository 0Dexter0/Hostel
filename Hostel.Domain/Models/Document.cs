using System.ComponentModel.DataAnnotations.Schema;

namespace Hostel.Domain.Models;

public class Document : EntityBase
{
    [Column(TypeName = "character varying")]
    public string Url { get; set; }

    [Column(TypeName = "character varying")]
    public string DocumentType { get; set; }

    public int TenantId { get; set; }

    [ForeignKey("TenantId")]
    [InverseProperty("Documents")]
    public virtual Tenant Tenant { get; set; }
}
