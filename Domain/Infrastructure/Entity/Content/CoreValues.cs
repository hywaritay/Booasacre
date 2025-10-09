using System.ComponentModel.DataAnnotations;
using Booasacre.Domain.Infrastructure.Entity.Booasacre;

namespace Booasacre.Domain.Infrastructure.Entity.Content;

public class CoreValues: BaseEntity
{
    [Key]
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Icon { get; set; }
}