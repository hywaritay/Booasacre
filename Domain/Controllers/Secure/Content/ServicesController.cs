using Booasacre.Domain.Infrastructure.Entity.Content;
using Booasacre.Domain.Infrastructure.Repository.Booasacre;
using Booasacre.Domain.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Booasacre.Domain.Controllers.Secure.Content;

[ApiExplorerSettings(GroupName = Consts.SwaggerDocName.SecureAdmin.Slug)]
[Authorize(Roles = Consts.Vars.Roles.Admin)]
[ApiController]
[Route(Routes.ApiRoute.Secure.Content.Services.Base)]
public class ServicesController(
    IServicesRepository servicesRepository,
    ILogger<ServicesController> logger)
    : ControllerBase
{
    [HttpGet]
    [Route(Routes.ApiRoute.Secure.Content.Services.All)]
    public async Task<ApiResult> GetAllServices()
    {
        try
        {
            var services = servicesRepository.All();
            return await Task.FromResult(ApiResponse.Success(services));
        }
        catch (Exception e)
        {
            logger.LogError("error");
            return await Task.FromResult(ApiResponse.Error(ErrorHttp.Error, e));
        }
    }

    [Route(Routes.ApiRoute.Secure.Content.Services.Find)]
    [HttpGet]
    public async Task<ApiResult> FindService(int id)
    {
        try
        {
            var result = servicesRepository.Find(id);
            return await Task.FromResult(ApiResponse.Success(result));
        }
        catch (Exception e)
        {
            logger.LogError("error");
            return await Task.FromResult(ApiResponse.Error(ErrorHttp.Error, e));
        }
    }

    [HttpPost]
    [Route(Routes.ApiRoute.Secure.Content.Services.Create)]
    public async Task<ApiResult> CreateService(Services data)
    {
        try
        {
            var result = servicesRepository.Create(data);
            if (!result) return await Task.FromResult(ApiResponse.Error(ErrorHttp.Error));

            return await Task.FromResult(ApiResponse.Success(result));
        }
        catch (Exception e)
        {
            logger.LogError("error");
            return await Task.FromResult(ApiResponse.Error(ErrorHttp.Error, e));
        }
    }

    [Route(Routes.ApiRoute.Secure.Content.Services.Update)]
    [HttpPost]
    public async Task<ApiResult> UpdateService(Services data)
    {
        try
        {
            var service = servicesRepository.Find(data.Id);
            if (service == null) return await Task.FromResult(ApiResponse.Error(ErrorHttp.NotFound));

            service.Title = data.Title;
            service.Description = data.Description;
            service.Icon = data.Icon;

            var result = servicesRepository.Update(service);
            if (!result) return await Task.FromResult(ApiResponse.Error(ErrorHttp.DbUpdateError));

            return await Task.FromResult(ApiResponse.Success(result));
        }
        catch (Exception e)
        {
            logger.LogError("error");
            return await Task.FromResult(ApiResponse.Error(ErrorHttp.Error, e));
        }
    }

    [Route(Routes.ApiRoute.Secure.Content.Services.Delete)]
    [HttpDelete]
    public async Task<ApiResult> DeleteService(int id)
    {
        try
        {
            var result = servicesRepository.Delete(id);
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

    [Route(Routes.ApiRoute.Secure.Content.Services.State)]
    [HttpGet]
    public async Task<ApiResult> StateService(int id, bool active)
    {
        try
        {
            var result = servicesRepository.Status(id, active);
            return await Task.FromResult(result ? ApiResponse.Success(result) : ApiResponse.Error(ErrorHttp.NotFound));
        }
        catch (Exception e)
        {
            logger.LogError("error");
            return await Task.FromResult(ApiResponse.Error(ErrorHttp.Error, e));
        }
    }
}