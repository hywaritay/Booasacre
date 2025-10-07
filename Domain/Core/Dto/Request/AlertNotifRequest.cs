using System.ComponentModel.DataAnnotations;

namespace Booasacre.Domain.Core.Dto.Request;

public class AlertNotifRequest
{
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
}