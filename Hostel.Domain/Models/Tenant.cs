using System.ComponentModel.DataAnnotations.Schema;

namespace Hostel.Domain.Models;

[Table("Tenants")]
public class Tenant : EntityBase
{
    [Column(TypeName = "character varying")]
    public string FirstName { get; set; }

    [Column(TypeName = "character varying")]
    public string LastName { get; set; }

    [Column(TypeName = "character varying")]
    public string Patronymic { get; set; }

    [Column(TypeName = "character varying")]
    public string PhoneNumber { get; set; }

    [Column(TypeName = "character varying")]
    public string Sex { get; set; }

    [Column(TypeName = "character varying")]
    public string Role { get; set; }

    public DateOnly CheckInDate { get; set; }

    public DateOnly CheckOutDate { get; set; }

    public int HostelId { get; set; }

    public int RoomId { get; set; }

    [InverseProperty("Tenant")]
    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    [ForeignKey("HostelId")]
    [InverseProperty("Tenants")]
    public virtual Hostel Hostel { get; set; }

    [ForeignKey("RoomId")]
    [InverseProperty("Tenants")]
    public virtual Room Room { get; set; }

    [InverseProperty("Tenant")]
    public virtual ICollection<Visit> Visits { get; set; } = new List<Visit>();
}
