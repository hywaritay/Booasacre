using Booasacre.Domain.Infrastructure.Entity.Content;
using Booasacre.Domain.Infrastructure.Repository.Booasacre;
using Booasacre.Domain.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Booasacre.Domain.Controllers.Secure.Content;

[ApiExplorerSettings(GroupName = Consts.SwaggerDocName.SecureAdmin.Slug)]
[Authorize(Roles = Consts.Vars.Roles.Admin)]
[ApiController]
[Route(Routes.ApiRoute.Secure.Content.TeamMembers.Base)]
public class TeamMembersController(
    ITeamMembersRepository teamMembersRepository,
    ILogger<TeamMembersController> logger)
    : ControllerBase
{
    [HttpGet]
    [Route(Routes.ApiRoute.Secure.Content.TeamMembers.All)]
    public async Task<ApiResult> GetAllTeamMembers()
    {
        try
        {
            var teamMembers = teamMembersRepository.All();
            foreach (var member in teamMembers.Where(member => !string.IsNullOrEmpty(member.ImageFile)))
            {
                member.Image = member.ImageFile;
            }
            return await Task.FromResult(ApiResponse.Success(teamMembers));
        }
        catch (Exception e)
        {
            logger.LogError("error");
            return await Task.FromResult(ApiResponse.Error(ErrorHttp.Error, e));
        }
    }

    [Route(Routes.ApiRoute.Secure.Content.TeamMembers.Find)]
    [HttpGet]
    public async Task<ApiResult> FindTeamMember(int id)
    {
        try
        {
            var result = teamMembersRepository.Find(id);
            return await Task.FromResult(ApiResponse.Success(result));
        }
        catch (Exception e)
        {
            logger.LogError("error");
            return await Task.FromResult(ApiResponse.Error(ErrorHttp.Error, e));
        }
    }

    [HttpPost]
    [Route(Routes.ApiRoute.Secure.Content.TeamMembers.Create)]
    public async Task<ApiResult> CreateTeamMember([FromForm] TeamMembers data, IFormFile? file)
    {
        try
        {
            if (file is { Length: > 0 })
            {
                using var ms = new MemoryStream();
                await file.CopyToAsync(ms);
                var imageBytes = ms.ToArray();
                var base64String = Convert.ToBase64String(imageBytes);
                data.ImageFile = $"data:{file.ContentType};base64,{base64String}";
                data.ImageName = file.FileName;
                data.ImageType = file.ContentType;
            }
            var result = teamMembersRepository.Create(data);
            if (!result) return await Task.FromResult(ApiResponse.Error(ErrorHttp.Error));
            return await Task.FromResult(ApiResponse.Success(result));
        }
        catch (Exception e)
        {
            logger.LogError("error");
            return await Task.FromResult(ApiResponse.Error(ErrorHttp.Error, e));
        }
    }

    [Route(Routes.ApiRoute.Secure.Content.TeamMembers.Update)]
    [HttpPost]
    public async Task<ApiResult> UpdateTeamMember(TeamMembers data)
    {
        try
        {
            var teamMember = teamMembersRepository.Find(data.Id);
            if (teamMember == null) return await Task.FromResult(ApiResponse.Error(ErrorHttp.NotFound));

            teamMember.Name = data.Name;
            teamMember.Title = data.Title;
            teamMember.Image = data.Image;

            var result = teamMembersRepository.Update(teamMember);
            if (!result) return await Task.FromResult(ApiResponse.Error(ErrorHttp.DbUpdateError));

            return await Task.FromResult(ApiResponse.Success(result));
        }
        catch (Exception e)
        {
            logger.LogError("error");
            return await Task.FromResult(ApiResponse.Error(ErrorHttp.Error, e));
        }
    }

    [Route(Routes.ApiRoute.Secure.Content.TeamMembers.Delete)]
    [HttpDelete]
    public async Task<ApiResult> DeleteTeamMember(int id)
    {
        try
        {
            var result = teamMembersRepository.Delete(id);
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

    [Route(Routes.ApiRoute.Secure.Content.TeamMembers.State)]
    [HttpGet]
    public async Task<ApiResult> StateTeamMember(int id, bool active)
    {
        try
        {
            var result = teamMembersRepository.Status(id, active);
            return await Task.FromResult(result ? ApiResponse.Success(result) : ApiResponse.Error(ErrorHttp.NotFound));
        }
        catch (Exception e)
        {
            logger.LogError("error");
            return await Task.FromResult(ApiResponse.Error(ErrorHttp.Error, e));
        }
    }
}