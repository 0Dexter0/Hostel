using System.ComponentModel.DataAnnotations.Schema;

namespace Hostel.Domain.Models;

[Table("Personal")]
public class Personal : EntityBase
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
    public string Role { get; set; }

    [Column(TypeName = "character varying")]
    public string Password { get; set; }

    public int HostelId { get; set; }

    [ForeignKey("HostelId")]
    [InverseProperty("Personals")]
    public virtual Hostel Hostel { get; set; }

    [InverseProperty("Personal")]
    public virtual ICollection<Visit> Visits { get; set; } = new List<Visit>();
}
