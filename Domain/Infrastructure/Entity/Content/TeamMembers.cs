using System.ComponentModel.DataAnnotations;
using Booasacre.Domain.Infrastructure.Entity.Booasacre;

namespace Booasacre.Domain.Infrastructure.Entity.Content;

public class TeamMembers: BaseEntity
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Title { get; set; }
    public string? Image { get; set; }
    public string? ImageFile { get; set; }
    public string? ImageName { get; set; }
    public string? ImageType { get; set; }
    public long? ImageSize { get; set; }
}