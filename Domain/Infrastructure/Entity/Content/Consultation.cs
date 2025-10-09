using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Booasacre.Domain.Infrastructure.Entity.Booasacre;

namespace Booasacre.Domain.Infrastructure.Entity.Content;

public class Consultation: BaseEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string? FirstName { get; set; }
    [Required]
    public string? LastName { get; set; }
    [Required]
    [EmailAddress]
    public string? Email { get; set; }
    [Required]
    [Phone]
    public string PhoneNumber { get; set; } = null!;
    public string? Company { get; set; }
    public double Budget { get; set; }
    [Required]
    public string Timeline { get; set; } = null!;
    [Required]
    public string ChallengeDescription { get; set; } = null!;
    public Services? FKService { get; set; }
}