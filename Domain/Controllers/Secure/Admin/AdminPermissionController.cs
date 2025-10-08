using Booasacre.Domain.Infrastructure.Entity.Booasacre;
using Booasacre.Domain.Infrastructure.Repository.Booasacre;
using Booasacre.Domain.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Booasacre.Domain.Controllers.Secure.Admin;

[ApiExplorerSettings(GroupName = Consts.SwaggerDocName.SecureAdmin.Slug)]
//[Authorize(Roles = Consts.Vars.Roles.Admin)]
[ApiController]
[Route(Routes.ApiRoute.Secure.Admin.Permission.Base)]
public class AdminPermissionController(IApiPermissionRepository apiPermissionRepository, ILogger<AdminPermissionController> logger)
    : ControllerBase
{
    [HttpGet]
    [Route(Routes.ApiRoute.Secure.Admin.Permission.All)]
    public async Task<ApiResult> Permissions()
    {
        try
        {
            var users = apiPermissionRepository.All();
            return await Task.FromResult(ApiResponse.Success(users));
        }
        catch (Exception e)
        {
            logger.LogError("error");
            return await Task.FromResult(ApiResponse.Error(ErrorHttp.Error, e));
        }
    }

    [HttpGet]
    [Route(Routes.ApiRoute.Secure.Admin.Permission.Find)]
    public async Task<ApiResult> FindPermission(int id)
    {
        try
        {
            var result = apiPermissionRepository.Find(id);
            return await Task.FromResult(ApiResponse.Success(result));
        }
        catch (Exception e)
        {
            logger.LogError("error");
            return await Task.FromResult(ApiResponse.Error(ErrorHttp.Error, e));
        }
    }

    [HttpPost]
    [Route(Routes.ApiRoute.Secure.Admin.Permission.Create)]
    public async Task<ApiResult> CreatePermission(ApiPermission data)
    {
        try
        {
            var result = apiPermissionRepository.Create(data);
            return await Task.FromResult(result ? ApiResponse.Success(result) : ApiResponse.Error(ErrorHttp.Error));
        }
        catch (Exception e)
        {
            logger.LogError("error");
            return await Task.FromResult(ApiResponse.Error(ErrorHttp.Error, e));
        }
    }

    [HttpPost]
    [Route(Routes.ApiRoute.Secure.Admin.Permission.Update)]
    public async Task<ApiResult> UpdatePermission(ApiPermission data)
    {
        try
        {
            var result = apiPermissionRepository.Update(data);
            return await Task.FromResult(result ? ApiResponse.Success(result) : ApiResponse.Error(ErrorHttp.NotFound));
        }
        catch (Exception e)
        {
            logger.LogError("error");
            return await Task.FromResult(ApiResponse.Error(ErrorHttp.Error, e));
        }
    }

    [Route(Routes.ApiRoute.Secure.Admin.Permission.Delete)]
    [HttpDelete]
    public async Task<ApiResult> DeletePermission(int id)
    {
        try
        {
            var result = apiPermissionRepository.Delete(id);
            return await Task.FromResult(result
                ? ApiResponse.Success(new object())
                : ApiResponse.Error(ErrorHttp.NotFound));
        }
        catch (Exception e)
        {
            logger.LogError("error");
            return await Task.FromResult(ApiResponse.Error(ErrorHttp.Error, e));
        }
    }
    [HttpGet]
    [Route(Routes.ApiRoute.Secure.Admin.Permission.State)]
    public async Task<ApiResult> StatePermission(int id, bool active)
    {
        try
        {
            var result = apiPermissionRepository.Status(id, active);
            return await Task.FromResult(result ? ApiResponse.Success(result) : ApiResponse.Error(ErrorHttp.NotFound));
        }
        catch (Exception e)
        {
            logger.LogError("error");
            return await Task.FromResult(ApiResponse.Error(ErrorHttp.Error, e));
        }
    }
}