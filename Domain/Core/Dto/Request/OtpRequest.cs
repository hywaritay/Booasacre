using System.ComponentModel.DataAnnotations;

namespace Booasacre.Domain.Core.Dto.Request;

public class OtpRequest
{
    [MaxLength(300)]
    public string? Email { get; set; }
    [MaxLength(50)]
    public string? Phone { get; set; }
    [MaxLength(300)]
    public string? Purpose { get; set; }
}