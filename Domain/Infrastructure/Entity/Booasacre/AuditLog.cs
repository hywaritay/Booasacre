using System.ComponentModel.DataAnnotations;

namespace Booasacre.Domain.Infrastructure.Entity.Booasacre;

public class AuditLog : BaseEntity
{
    [Key] public int Id { get; set; }
    
    [MaxLength(150)]
    public string? Name { get; set; }
    
    [MaxLength(150)]
    public string? IpAddress { get; set; }
    
    [MaxLength(1000)]
    public string? Url { get; set; }
    
    [MaxLength(1000)]
    public string? QueryString { get; set; }
    
    public string? Payload { get; set; }
    public string? Response { get; set; }
    public string? RequestHeaders { get; set; }
    public string? RequestContentType { get; set; }
    public string? RequestMethod { get; set; }
    public string? ResponseStatusCode { get; set; }
    public string? ResponseHeaders { get; set; }
    public string? ResponseContentType { get; set; }
    public DateTime? ResponseTimestamp { get; set; }
    
    [MaxLength(1000)]
    public string? User { get; set; }
}