using Booasacre.Domain.Infrastructure.Entity.Content;
using Booasacre.Domain.Infrastructure.Repository.Booasacre;
using Booasacre.Domain.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Booasacre.Domain.Controllers.Secure.Content;

[ApiExplorerSettings(GroupName = Consts.SwaggerDocName.SecureAdmin.Slug)]
[Authorize(Roles = Consts.Vars.Roles.Admin)]
[ApiController]
[Route(Routes.ApiRoute.Secure.Content.CoreValues.Base)]
public class CoreValuesController(
    ICoreValuesRepository coreValuesRepository,
    ILogger<CoreValuesController> logger)
    : ControllerBase
{
    [HttpGet]
    [Route(Routes.ApiRoute.Secure.Content.CoreValues.All)]
    public async Task<ApiResult> GetAllCoreValues()
    {
        try
        {
            var coreValues = coreValuesRepository.All();
            return await Task.FromResult(ApiResponse.Success(coreValues));
        }
        catch (Exception e)
        {
            logger.LogError("error");
            return await Task.FromResult(ApiResponse.Error(ErrorHttp.Error, e));
        }
    }

    [Route(Routes.ApiRoute.Secure.Content.CoreValues.Find)]
    [HttpGet]
    public async Task<ApiResult> FindCoreValue(int id)
    {
        try
        {
            var result = coreValuesRepository.Find(id);
            return await Task.FromResult(ApiResponse.Success(result));
        }
        catch (Exception e)
        {
            logger.LogError("error");
            return await Task.FromResult(ApiResponse.Error(ErrorHttp.Error, e));
        }
    }

    [HttpPost]
    [Route(Routes.ApiRoute.Secure.Content.CoreValues.Create)]
    public async Task<ApiResult> CreateCoreValue(CoreValues data)
    {
        try
        {
            var result = coreValuesRepository.Create(data);
            if (!result) return await Task.FromResult(ApiResponse.Error(ErrorHttp.Error));

            return await Task.FromResult(ApiResponse.Success(result));
        }
        catch (Exception e)
        {
            logger.LogError("error");
            return await Task.FromResult(ApiResponse.Error(ErrorHttp.Error, e));
        }
    }

    [Route(Routes.ApiRoute.Secure.Content.CoreValues.Update)]
    [HttpPost]
    public async Task<ApiResult> UpdateCoreValue(CoreValues data)
    {
        try
        {
            var coreValue = coreValuesRepository.Find(data.Id);
            if (coreValue == null) return await Task.FromResult(ApiResponse.Error(ErrorHttp.NotFound));

            coreValue.Title = data.Title;
            coreValue.Description = data.Description;
            coreValue.Icon = data.Icon;

            var result = coreValuesRepository.Update(coreValue);
            if (!result) return await Task.FromResult(ApiResponse.Error(ErrorHttp.DbUpdateError));

            return await Task.FromResult(ApiResponse.Success(result));
        }
        catch (Exception e)
        {
            logger.LogError("error");
            return await Task.FromResult(ApiResponse.Error(ErrorHttp.Error, e));
        }
    }

    [Route(Routes.ApiRoute.Secure.Content.CoreValues.Delete)]
    [HttpDelete]
    public async Task<ApiResult> DeleteCoreValue(int id)
    {
        try
        {
            var result = coreValuesRepository.Delete(id);
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

    [Route(Routes.ApiRoute.Secure.Content.CoreValues.State)]
    [HttpGet]
    public async Task<ApiResult> StateCoreValue(int id, bool active)
    {
        try
        {
            var result = coreValuesRepository.Status(id, active);
            return await Task.FromResult(result ? ApiResponse.Success(result) : ApiResponse.Error(ErrorHttp.NotFound));
        }
        catch (Exception e)
        {
            logger.LogError("error");
            return await Task.FromResult(ApiResponse.Error(ErrorHttp.Error, e));
        }
    }
}