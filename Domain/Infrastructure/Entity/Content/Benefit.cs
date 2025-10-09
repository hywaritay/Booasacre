using System.ComponentModel.DataAnnotations;
using Booasacre.Domain.Infrastructure.Entity.Booasacre;

namespace Booasacre.Domain.Infrastructure.Entity.Content;

public class Benefit: BaseEntity
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public Services? FKService { get; set; }
}