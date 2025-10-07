using System.ComponentModel.DataAnnotations;

namespace Booasacre.Domain.Infrastructure.Entity.Booasacre;

public class ApiUser : BaseEntity
{
    [Key] public int? Id { get; set; }
    
    [MaxLength(1000)]
    public string? ApiKey { get; set; }
    
    [MaxLength(3000)]
    public string? ApiSecret { get; set; }
    public int? ApiTokenMinute { get; set; }
    
    [MaxLength(300)]
    public string? Firstname { get; set; }
    
    [MaxLength(300)]
    public string? Lastname { get; set; }
    
    [MaxLength(300)]
    public string? Email { get; set; }
    
    [MaxLength(300)]
    public string? AccountFeeBank { get; set; }
    
    [MaxLength(300)]
    public string? AccountFeeCompany { get; set; }
    
    [MaxLength(300)]
    public string? Channel { get; set; }
    [MaxLength(300)]
    public string? ChannelName { get; set; }
    
    public double? LimitTransaction { get; init; }
    public double? LimitDaily { get; init; }
    public double? LimitTransactionWithCard { get; init; }
    public double? LimitDailyWithCard { get; init; }
    public double? InstantTransferLimitTransaction { get; set; }
    
    public bool? LimitWithCard { get; set; } = false;
    public bool? TransferAnyToAny { get; set; } = false;
    public bool? TransferOtherBank { get; set; } = false;
    public bool? InstantTransfer { get; set; } = false;
    public bool? RewriteExplCode { get; set; } = false;
    public DateTime? Lastconnect { get; set; }
    public List<ApiUserPermission>? UserPermissions { get; set; }
}