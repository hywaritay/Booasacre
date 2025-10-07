using Booasacre.Domain.Utils;

namespace Booasacre.Domain.Utils;

public static class ErrorHttp
{
    public static readonly ApiResultError Error = new() {Status = 0, ErrorCode = "ERROR", Message = "Error application"};
    public static readonly ApiResultError FormInvalid = new() {Status = 0, ErrorCode = "ERROR", Message = "One or some required fields are empty"};
    public static readonly ApiResultError WrongPhoneNumber = new() { Status = 0, ErrorCode = "ERROR", Message = "Wrong Phone Number" };
    public static readonly ApiResultError NotFound = new() {Status = 0, ErrorCode = "ERROR", Message = "Object not found"};
    public static readonly ApiResultError NotReachable = new() { Status = 0, ErrorCode = "ERROR", Message = "The service is not accessible, please try again now or later.", HttpCode = 500 };

    public static readonly ApiResultError DbOpenConnectionFailed = new() {Status = 0, ErrorCode = "ERROR", Message = "Database can't open"};
    public static readonly ApiResultError DbQueryRunFailed = new() {Status = 0, ErrorCode = "ERROR", Message = "Database query failed"};
    public static readonly ApiResultError DbCreateError = new() {Status = 0, ErrorCode = "ERROR", Message = "Failed to create"};
    public static readonly ApiResultError DbErrorObjectEmpty = new() {Status = 0, ErrorCode = "ERROR", Message = "Object empty, they is no field"};
    public static readonly ApiResultError DbUpdateError = new() {Status = 0, ErrorCode = "ERROR", Message = "Object not found"};
    public static readonly ApiResultError DbFindError = new() {Status = 0, ErrorCode = "ERROR", Message = "Object not found"};
    public static readonly ApiResultError DbStatusError = new() {Status = 0, ErrorCode = "ERROR", Message = "Status failed"};
    public static readonly ApiResultError DbDeleteError = new() {Status = 0, ErrorCode = "ERROR", Message = "Delete failed"};
    
    public static readonly ApiResultError NotEncoded = new() {Status = 0, ErrorCode = "ERROR", Message = "Data not encoded"};
    public static readonly ApiResultError UserNotFound = new() {Status = 0, ErrorCode = "ERROR", Message = "User not found"};
    public static readonly ApiResultError UsernameUsed = new() {Status = 0, ErrorCode = "ERROR", Message = "Username already used by another existing account"};
    public static readonly ApiResultError EmailUsed = new() {Status = 0, ErrorCode = "ERROR", Message = "Email address already used by another existing account"};
    public static readonly ApiResultError OtpExpired = new() {Status = 0, ErrorCode = "ERROR", Message = "OTP has expired"};
    public static readonly ApiResultError Unauthorized = new() {Status = 0, ErrorCode = "ERROR", Message = "Unauthorized"};
    public static readonly ApiResultError BasicCredentialMissed = new() {Status = 0, ErrorCode = "ERROR", Message = "Basic credentials missed"};

    public static readonly ApiResultError BadBasicCredential = new() {Status = 0, ErrorCode = "ERROR", Message = "Bad Basic credentials"};
    public static readonly ApiResultError BadCredentials = new() {Status = 0, ErrorCode = "ERROR", Message = "bad credentials"};
   }