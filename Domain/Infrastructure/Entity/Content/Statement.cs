using System.ComponentModel.DataAnnotations;
using Booasacre.Domain.Infrastructure.Entity.Booasacre;

namespace Booasacre.Domain.Infrastructure.Entity.Content;

public class Statement: BaseEntity
{
    [Key]
    public int Id { get; set; }
    public string? Mission { get; set; }
    public string? Vision { get; set; }
    public string? Expertise { get; set; }
}