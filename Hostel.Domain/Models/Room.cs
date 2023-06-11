using System.ComponentModel.DataAnnotations.Schema;

namespace Hostel.Domain.Models;

[Table("Rooms")]
public class Room : EntityBase
{
    [Column(TypeName = "character varying")]
    public string Number { get; set; }

    public int MaxPeople { get; set; }

    [Column(TypeName = "character varying")]
    public string ForSex { get; set; }

    public int HostelId { get; set; }

    [ForeignKey("HostelId")]
    [InverseProperty("Rooms")]
    public virtual Hostel Hostel { get; set; }

    [InverseProperty("Room")]
    public virtual ICollection<Tenant> Tenants { get; set; } = new List<Tenant>();
}
