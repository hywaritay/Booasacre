using System.ComponentModel.DataAnnotations;

namespace Booasacre.Domain.Infrastructure.Entity.Booasacre;

public class ApiPermission : BaseEntity
{
    public int? Id { get; set; }
    
    [MaxLength(300)]
    public string? Name { get; set; }
}