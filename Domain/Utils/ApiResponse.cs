using System.ComponentModel;

namespace Booasacre.Domain.Utils;

public static class ApiResponse
{
    public static ApiResult Success(
        dynamic? data = null, string? message = null,
        int? pages = null, int? pageIndex = null
    )
    {
        return new ApiResultSuccess
        {
            Data = data, Status = 1, Message = message ?? "success",
            Pages = pages,
            PageIndex = pageIndex
        };
    }

    public static ApiResult Error(ApiResultError? errorHttp, Exception? exception = null)
    {
        var error = errorHttp ?? ErrorHttp.Error;
        if (exception is Except except)
        {
            error.ErrorCode = except.ErrorCode;
        }
        error.Message = exception == null ? error.Message : exception.Message;
        error.Exception = exception == null ? "" : exception.ToString();
        return error;
    }
    
    public static ApiResult ErrorWithMessage(ApiResultError? errorHttp, string? message = null)
    {
        var error = errorHttp ?? ErrorHttp.Error;
        error.Message = message ?? "";
        return error;
    }
}

public class ApiResult
{
    [DefaultValue(1)] 
    public int Status { get; set; } = 1;
    public string? Message { get; set; } = "success";
}

public class ApiResultSuccess : ApiResult
{
    public dynamic? Data { get; set; } = null;
    public int? Pages { get; set; } = 1;
    public int? PageIndex { get; set; } = null;
}

public class ApiResultError : ApiResult
{
    public new int Status { get; set; } = 0;
    public string? ErrorCode { get; set; } = "ERROR";
    public int HttpCode { get; set; } = 500;
    public string? Exception { get; set; }
}