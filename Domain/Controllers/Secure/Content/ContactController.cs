using Booasacre.Domain.Infrastructure.Entity.Content;
using Booasacre.Domain.Infrastructure.Repository.Booasacre;
using Booasacre.Domain.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Booasacre.Domain.Controllers.Secure.Content;

[ApiExplorerSettings(GroupName = Consts.SwaggerDocName.SecureAdmin.Slug)]
[Authorize(Roles = Consts.Vars.Roles.Admin)]
[ApiController]
[Route(Routes.ApiRoute.Secure.Content.Contact.Base)]
public class ContactController(
    IContactRepository contactRepository,
    ILogger<ContactController> logger)
    : ControllerBase
{
    [HttpGet]
    [Route(Routes.ApiRoute.Secure.Content.Contact.All)]
    public async Task<ApiResult> GetAllContacts()
    {
        try
        {
            var contacts = contactRepository.All();
            return await Task.FromResult(ApiResponse.Success(contacts));
        }
        catch (Exception e)
        {
            logger.LogError("error");
            return await Task.FromResult(ApiResponse.Error(ErrorHttp.Error, e));
        }
    }

    [Route(Routes.ApiRoute.Secure.Content.Contact.Find)]
    [HttpGet]
    public async Task<ApiResult> FindContact(int id)
    {
        try
        {
            var result = contactRepository.Find(id);
            return await Task.FromResult(ApiResponse.Success(result));
        }
        catch (Exception e)
        {
            logger.LogError("error");
            return await Task.FromResult(ApiResponse.Error(ErrorHttp.Error, e));
        }
    }

    [HttpPost]
    [Route(Routes.ApiRoute.Secure.Content.Contact.Create)]
    public async Task<ApiResult> CreateContact(Contact data)
    {
        try
        {
            var result = contactRepository.Create(data);
            if (!result) return await Task.FromResult(ApiResponse.Error(ErrorHttp.Error));

            return await Task.FromResult(ApiResponse.Success(result));
        }
        catch (Exception e)
        {
            logger.LogError("error");
            return await Task.FromResult(ApiResponse.Error(ErrorHttp.Error, e));
        }
    }

    [Route(Routes.ApiRoute.Secure.Content.Contact.Update)]
    [HttpPost]
    public async Task<ApiResult> UpdateContact(Contact data)
    {
        try
        {
            var contact = contactRepository.Find(data.Id);
            if (contact == null) return await Task.FromResult(ApiResponse.Error(ErrorHttp.NotFound));

            contact.FirstName = data.FirstName;
            contact.LastName = data.LastName;
            contact.Email = data.Email;
            contact.PhoneNumber = data.PhoneNumber;
            contact.Company = data.Company;
            contact.Subject = data.Subject;
            contact.Message = data.Message;

            var result = contactRepository.Update(contact);
            if (!result) return await Task.FromResult(ApiResponse.Error(ErrorHttp.DbUpdateError));

            return await Task.FromResult(ApiResponse.Success(result));
        }
        catch (Exception e)
        {
            logger.LogError("error");
            return await Task.FromResult(ApiResponse.Error(ErrorHttp.Error, e));
        }
    }

    [Route(Routes.ApiRoute.Secure.Content.Contact.Delete)]
    [HttpDelete]
    public async Task<ApiResult> DeleteContact(int id)
    {
        try
        {
            var result = contactRepository.Delete(id);
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

    [Route(Routes.ApiRoute.Secure.Content.Contact.State)]
    [HttpGet]
    public async Task<ApiResult> StateContact(int id, bool active)
    {
        try
        {
            var result = contactRepository.Status(id, active);
            return await Task.FromResult(result ? ApiResponse.Success(result) : ApiResponse.Error(ErrorHttp.NotFound));
        }
        catch (Exception e)
        {
            logger.LogError("error");
            return await Task.FromResult(ApiResponse.Error(ErrorHttp.Error, e));
        }
    }
}