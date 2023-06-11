using System.ComponentModel.DataAnnotations.Schema;

namespace Hostel.Domain.Models;

[Table("Hostels")]
public class Hostel : EntityBase
{
    [Column(TypeName = "character varying")]
    public string Address { get; set; }

    public int Number { get; set; }

    [Column(TypeName = "character varying")]
    public string Description { get; set; }

    [InverseProperty("Hostel")]
    public virtual ICollection<Personal> Personals { get; set; } = new List<Personal>();

    [InverseProperty("Hostel")]
    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();

    [InverseProperty("Hostel")]
    public virtual ICollection<Tenant> Tenants { get; set; } = new List<Tenant>();

    [InverseProperty("Hostel")]
    public virtual ICollection<Visit> Visits { get; set; } = new List<Visit>();
}
