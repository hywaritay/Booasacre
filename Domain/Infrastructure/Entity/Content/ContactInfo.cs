using System.ComponentModel.DataAnnotations;
using Booasacre.Domain.Infrastructure.Entity.Booasacre;

namespace Booasacre.Domain.Infrastructure.Entity.Content;

public class ContactInfo: BaseEntity
{
    [Key]
    public int Id { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Office { get; set; }
    public string? BusinessHours { get; set; }
}