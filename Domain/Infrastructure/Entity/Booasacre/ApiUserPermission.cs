using System.ComponentModel.DataAnnotations;

namespace Booasacre.Domain.Infrastructure.Entity.Booasacre;

public class ApiUserPermission : BaseEntity
{
    [Key] public int? Id { get; set; }
    
    [MaxLength(300)]
    public string? Name { get; set; }
    public ApiUser? FkUser { get; set; }
    public ApiPermission? FkPermission { get; set; }
}