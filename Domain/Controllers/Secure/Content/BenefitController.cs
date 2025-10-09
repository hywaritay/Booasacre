using Booasacre.Domain.Infrastructure.Entity.Content;
using Booasacre.Domain.Infrastructure.Repository.Booasacre;
using Booasacre.Domain.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Booasacre.Domain.Controllers.Secure.Content;

[ApiExplorerSettings(GroupName = Consts.SwaggerDocName.SecureAdmin.Slug)]
[Authorize(Roles = Consts.Vars.Roles.Admin)]
[ApiController]
[Route(Routes.ApiRoute.Secure.Content.Benefit.Base)]
public class BenefitController(
    IBenefitRepository benefitRepository,
    IServicesRepository apiServiceRepository,
    ILogger<BenefitController> logger)
    : ControllerBase
{
    [HttpGet]
    [Route(Routes.ApiRoute.Secure.Content.Benefit.All)]
    public async Task<ApiResult> GetAllBenefits()
    {
        try
        {
            var benefits = benefitRepository.All();
            return await Task.FromResult(ApiResponse.Success(benefits));
        }
        catch (Exception e)
        {
            logger.LogError("error");
            return await Task.FromResult(ApiResponse.Error(ErrorHttp.Error, e));
        }
    }

    [Route(Routes.ApiRoute.Secure.Content.Benefit.Find)]
    [HttpGet]
    public async Task<ApiResult> FindBenefit(int id)
    {
        try
        {
            var result = benefitRepository.Find(id);
            return await Task.FromResult(ApiResponse.Success(result));
        }
        catch (Exception e)
        {
            logger.LogError("error");
            return await Task.FromResult(ApiResponse.Error(ErrorHttp.Error, e));
        }
    }

    [HttpPost]
    [Route(Routes.ApiRoute.Secure.Content.Benefit.Create)]
    public async Task<ApiResult> CreateBenefit(Benefit data)
    {
        
        try
        {
            var service = apiServiceRepository.Find(data.FKService?.Id);
            if (service == null)
                return await Task.FromResult(ApiResponse.Error(ErrorHttp.NotFound));
            data.FKService = service;
            var result = benefitRepository.Create(data);
            if (!result) return await Task.FromResult(ApiResponse.Error(ErrorHttp.Error));

            return await Task.FromResult(ApiResponse.Success(result));
        }
        catch (Exception e)
        {
            logger.LogError("error");
            return await Task.FromResult(ApiResponse.Error(ErrorHttp.Error, e));
        }
    }

    [Route(Routes.ApiRoute.Secure.Content.Benefit.Update)]
    [HttpPost]
    public async Task<ApiResult> UpdateBenefit(Benefit data)
    {
        try
        {
            var benefit = benefitRepository.Find(data.Id);
            if (benefit == null) return await Task.FromResult(ApiResponse.Error(ErrorHttp.NotFound));

            benefit.Name = data.Name;
            benefit.FKService = data.FKService;

            var result = benefitRepository.Update(benefit);
            if (!result) return await Task.FromResult(ApiResponse.Error(ErrorHttp.DbUpdateError));

            return await Task.FromResult(ApiResponse.Success(result));
        }
        catch (Exception e)
        {
            logger.LogError("error");
            return await Task.FromResult(ApiResponse.Error(ErrorHttp.Error, e));
        }
    }

    [Route(Routes.ApiRoute.Secure.Content.Benefit.Delete)]
    [HttpDelete]
    public async Task<ApiResult> DeleteBenefit(int id)
    {
        try
        {
            var result = benefitRepository.Delete(id);
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

    [Route(Routes.ApiRoute.Secure.Content.Benefit.State)]
    [HttpGet]
    public async Task<ApiResult> StateBenefit(int id, bool active)
    {
        try
        {
            var result = benefitRepository.Status(id, active);
            return await Task.FromResult(result ? ApiResponse.Success(result) : ApiResponse.Error(ErrorHttp.NotFound));
        }
        catch (Exception e)
        {
            logger.LogError("error");
            return await Task.FromResult(ApiResponse.Error(ErrorHttp.Error, e));
        }
    }
}