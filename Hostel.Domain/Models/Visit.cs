using System.ComponentModel.DataAnnotations.Schema;

namespace Hostel.Domain.Models;

[Table("Visits")]
public class Visit : EntityBase
{
    public DateOnly Date { get; set; }

    [Column(TypeName = "character varying")]
    public string Description { get; set; }

    public int TenantId { get; set; }

    public int PersonalId { get; set; }

    public int HostelId { get; set; }

    [ForeignKey("HostelId")]
    [InverseProperty("Visits")]
    public virtual Hostel Hostel { get; set; }

    [ForeignKey("PersonalId")]
    [InverseProperty("Visits")]
    public virtual Personal Personal { get; set; }

    [ForeignKey("TenantId")]
    [InverseProperty("Visits")]
    public virtual Tenant Tenant { get; set; }
}
