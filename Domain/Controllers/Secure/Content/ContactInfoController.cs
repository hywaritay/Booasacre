using Booasacre.Domain.Infrastructure.Entity.Content;
using Booasacre.Domain.Infrastructure.Repository.Booasacre;
using Booasacre.Domain.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Booasacre.Domain.Controllers.Secure.Content;

[ApiExplorerSettings(GroupName = Consts.SwaggerDocName.SecureAdmin.Slug)]
[Authorize(Roles = Consts.Vars.Roles.Admin)]
[ApiController]
[Route(Routes.ApiRoute.Secure.Content.ContactInfo.Base)]
public class ContactInfoController(
    IContactInfoRepository contactInfoRepository,
    ILogger<ContactInfoController> logger)
    : ControllerBase
{
    [HttpGet]
    [Route(Routes.ApiRoute.Secure.Content.ContactInfo.All)]
    public async Task<ApiResult> GetAllContactInfo()
    {
        try
        {
            var contactInfo = contactInfoRepository.All();
            return await Task.FromResult(ApiResponse.Success(contactInfo));
        }
        catch (Exception e)
        {
            logger.LogError("error");
            return await Task.FromResult(ApiResponse.Error(ErrorHttp.Error, e));
        }
    }

    [Route(Routes.ApiRoute.Secure.Content.ContactInfo.Find)]
    [HttpGet]
    public async Task<ApiResult> FindContactInfo(int id)
    {
        try
        {
            var result = contactInfoRepository.Find(id);
            return await Task.FromResult(ApiResponse.Success(result));
        }
        catch (Exception e)
        {
            logger.LogError("error");
            return await Task.FromResult(ApiResponse.Error(ErrorHttp.Error, e));
        }
    }

    [HttpPost]
    [Route(Routes.ApiRoute.Secure.Content.ContactInfo.Create)]
    public async Task<ApiResult> CreateContactInfo(ContactInfo data)
    {
        try
        {
            var result = contactInfoRepository.Create(data);
            if (!result) return await Task.FromResult(ApiResponse.Error(ErrorHttp.Error));

            return await Task.FromResult(ApiResponse.Success(result));
        }
        catch (Exception e)
        {
            logger.LogError("error");
            return await Task.FromResult(ApiResponse.Error(ErrorHttp.Error, e));
        }
    }

    [Route(Routes.ApiRoute.Secure.Content.ContactInfo.Update)]
    [HttpPost]
    public async Task<ApiResult> UpdateContactInfo(ContactInfo data)
    {
        try
        {
            var contactInfo = contactInfoRepository.Find(data.Id);
            if (contactInfo == null) return await Task.FromResult(ApiResponse.Error(ErrorHttp.NotFound));

            contactInfo.Phone = data.Phone;
            contactInfo.Email = data.Email;
            contactInfo.Office = data.Office;
            contactInfo.BusinessHours = data.BusinessHours;

            var result = contactInfoRepository.Update(contactInfo);
            if (!result) return await Task.FromResult(ApiResponse.Error(ErrorHttp.DbUpdateError));

            return await Task.FromResult(ApiResponse.Success(result));
        }
        catch (Exception e)
        {
            logger.LogError("error");
            return await Task.FromResult(ApiResponse.Error(ErrorHttp.Error, e));
        }
    }

    [Route(Routes.ApiRoute.Secure.Content.ContactInfo.Delete)]
    [HttpDelete]
    public async Task<ApiResult> DeleteContactInfo(int id)
    {
        try
        {
            var result = contactInfoRepository.Delete(id);
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

    [Route(Routes.ApiRoute.Secure.Content.ContactInfo.State)]
    [HttpGet]
    public async Task<ApiResult> StateContactInfo(int id, bool active)
    {
        try
        {
            var result = contactInfoRepository.Status(id, active);
            return await Task.FromResult(result ? ApiResponse.Success(result) : ApiResponse.Error(ErrorHttp.NotFound));
        }
        catch (Exception e)
        {
            logger.LogError("error");
            return await Task.FromResult(ApiResponse.Error(ErrorHttp.Error, e));
        }
    }
}