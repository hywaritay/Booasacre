using System.ComponentModel.DataAnnotations;

namespace Booasacre.Domain.Infrastructure.Entity.Booasacre;

public class AlertNotif : BaseEntity
{
    [Key] public int? Id { get; set; }
    
    [MaxLength(50)]
    public string? Phone { get; set; }
    
    [MaxLength(1000)]
    public string? Sms { get; set; }
    
    [MaxLength(300)]
    public string? EmailSubject { get; set; }
    
    [MaxLength(300)]
    public string? EmailTo { get; set; }
    
    [MaxLength(300)]
    public string? EmailCc { get; set; }
    
    [MaxLength(300)]
    public string? EmailBcc { get; set; }
    
    [MaxLength(3000)]
    public string? EmailBody { get; set; }
    
    public bool? TransmitEmail { get; set; }
    public bool? TransmitPhone { get; set; }
    public ApiUser? FkUser { get; set; }
}