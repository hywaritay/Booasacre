using Booasacre.Domain.Infrastructure.Entity.Content;
using Booasacre.Domain.Infrastructure.Repository.Booasacre;
using Booasacre.Domain.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Booasacre.Domain.Controllers.Secure.Content;

[ApiExplorerSettings(GroupName = Consts.SwaggerDocName.SecureAdmin.Slug)]
[Authorize(Roles = Consts.Vars.Roles.Admin)]
[ApiController]
[Route(Routes.ApiRoute.Secure.Content.Consultation.Base)]
public class ConsultationController(
    IConsultationRepository consultationRepository,
    IServicesRepository apiServiceRepository,
    ILogger<ConsultationController> logger)
    : ControllerBase
{
    [HttpGet]
    [Route(Routes.ApiRoute.Secure.Content.Consultation.All)]
    public async Task<ApiResult> GetAllConsultations()
    {
        try
        {
            var consultations = consultationRepository.All();
            return await Task.FromResult(ApiResponse.Success(consultations));
        }
        catch (Exception e)
        {
            logger.LogError("error");
            return await Task.FromResult(ApiResponse.Error(ErrorHttp.Error, e));
        }
    }

    [Route(Routes.ApiRoute.Secure.Content.Consultation.Find)]
    [HttpGet]
    public async Task<ApiResult> FindConsultation(int id)
    {
        try
        {
            var result = consultationRepository.Find(id);
            return await Task.FromResult(ApiResponse.Success(result));
        }
        catch (Exception e)
        {
            logger.LogError("error");
            return await Task.FromResult(ApiResponse.Error(ErrorHttp.Error, e));
        }
    }

    [HttpPost]
    [Route(Routes.ApiRoute.Secure.Content.Consultation.Create)]
    public async Task<ApiResult> CreateConsultation(Consultation data)
    {
        try
        {
            var service = apiServiceRepository.Find(data.FKService?.Id);
            if (service == null)
                return await Task.FromResult(ApiResponse.Error(ErrorHttp.NotFound));
            data.FKService = service;
            var result = consultationRepository.Create(data);
            if (!result) return await Task.FromResult(ApiResponse.Error(ErrorHttp.Error));

            return await Task.FromResult(ApiResponse.Success(result));
        }
        catch (Exception e)
        {
            logger.LogError("error");
            return await Task.FromResult(ApiResponse.Error(ErrorHttp.Error, e));
        }
    }

    [Route(Routes.ApiRoute.Secure.Content.Consultation.Update)]
    [HttpPost]
    public async Task<ApiResult> UpdateConsultation(Consultation data)
    {
        try
        {
            var consultation = consultationRepository.Find(data.Id);
            if (consultation == null) return await Task.FromResult(ApiResponse.Error(ErrorHttp.NotFound));

            consultation.FirstName = data.FirstName;
            consultation.LastName = data.LastName;
            consultation.Email = data.Email;
            consultation.PhoneNumber = data.PhoneNumber;
            consultation.Company = data.Company;
            consultation.Budget = data.Budget;
            consultation.Timeline = data.Timeline;
            consultation.ChallengeDescription = data.ChallengeDescription;
            consultation.FKService = data.FKService;

            var result = consultationRepository.Update(consultation);
            if (!result) return await Task.FromResult(ApiResponse.Error(ErrorHttp.DbUpdateError));

            return await Task.FromResult(ApiResponse.Success(result));
        }
        catch (Exception e)
        {
            logger.LogError("error");
            return await Task.FromResult(ApiResponse.Error(ErrorHttp.Error, e));
        }
    }

    [Route(Routes.ApiRoute.Secure.Content.Consultation.Delete)]
    [HttpDelete]
    public async Task<ApiResult> DeleteConsultation(int id)
    {
        try
        {
            var result = consultationRepository.Delete(id);
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

    [Route(Routes.ApiRoute.Secure.Content.Consultation.State)]
    [HttpGet]
    public async Task<ApiResult> StateConsultation(int id, bool active)
    {
        try
        {
            var result = consultationRepository.Status(id, active);
            return await Task.FromResult(result ? ApiResponse.Success(result) : ApiResponse.Error(ErrorHttp.NotFound));
        }
        catch (Exception e)
        {
            logger.LogError("error");
            return await Task.FromResult(ApiResponse.Error(ErrorHttp.Error, e));
        }
    }
}