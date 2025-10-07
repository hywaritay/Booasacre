using System.ComponentModel.DataAnnotations;


namespace Booasacre.Domain.Infrastructure.Entity.Booasacre;


public class OneTimePassword : BaseEntity
{
    [Key] public int? Id { get; set; }
    [MaxLength(100)]
    public string? Reference { get; set; }
    [MaxLength(50)]
    public string? Otp { get; set; }
    [MaxLength(300)]
    public string? Email { get; set; }
    [MaxLength(50)]
    public string? Phone { get; set; }
    [MaxLength(300)]
    public string? Purpose { get; set; }
    public bool? TransmitEmail { get; set; }
    
    [MaxLength(300)] public string? TransmitStatus { get; set; }
    [MaxLength(300)] public string? ErrorCode { get; set; }
    [MaxLength(300)] public string? ErrorMessage { get; set; }
    
    public bool? TransmitPhone { get; set; }
    public bool? Used { get; set; }
    public DateTime? ExpiredDate { get; set; }
    public DateTime? TransmitEmailDate { get; set; }
    public DateTime? TransmitPhoneDate { get; set; }
    public DateTime? UsedTimeDate { get; set; }
    public ApiUser? FkUser { get; set; }
}