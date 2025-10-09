using System.ComponentModel.DataAnnotations;
using Booasacre.Domain.Infrastructure.Entity.Booasacre;

namespace Booasacre.Domain.Infrastructure.Entity.Content;

public class Contact: BaseEntity
{
    [Key]
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Company { get; set; }
    public string? Subject { get; set; }
    public string? Message { get; set; }
}