using Booasacre.Domain.Infrastructure.Entity.Content;
using Booasacre.Domain.Infrastructure.Repository.Booasacre;
using Booasacre.Domain.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Booasacre.Domain.Controllers.Secure.Content;

[ApiExplorerSettings(GroupName = Consts.SwaggerDocName.SecureAdmin.Slug)]
[Authorize(Roles = Consts.Vars.Roles.Admin)]
[ApiController]
[Route(Routes.ApiRoute.Secure.Content.Statement.Base)]
public class StatementController(
    IStatementRepository statementRepository,
    ILogger<StatementController> logger)
    : ControllerBase
{
    [HttpGet]
    [Route(Routes.ApiRoute.Secure.Content.Statement.All)]
    public async Task<ApiResult> GetAllStatements()
    {
        try
        {
            var statements = statementRepository.All();
            return await Task.FromResult(ApiResponse.Success(statements));
        }
        catch (Exception e)
        {
            logger.LogError("error");
            return await Task.FromResult(ApiResponse.Error(ErrorHttp.Error, e));
        }
    }

    [Route(Routes.ApiRoute.Secure.Content.Statement.Find)]
    [HttpGet]
    public async Task<ApiResult> FindStatement(int id)
    {
        try
        {
            var result = statementRepository.Find(id);
            return await Task.FromResult(ApiResponse.Success(result));
        }
        catch (Exception e)
        {
            logger.LogError("error");
            return await Task.FromResult(ApiResponse.Error(ErrorHttp.Error, e));
        }
    }

    [HttpPost]
    [Route(Routes.ApiRoute.Secure.Content.Statement.Create)]
    public async Task<ApiResult> CreateStatement(Statement data)
    {
        try
        {
            var result = statementRepository.Create(data);
            if (!result) return await Task.FromResult(ApiResponse.Error(ErrorHttp.Error));

            return await Task.FromResult(ApiResponse.Success(result));
        }
        catch (Exception e)
        {
            logger.LogError("error");
            return await Task.FromResult(ApiResponse.Error(ErrorHttp.Error, e));
        }
    }

    [Route(Routes.ApiRoute.Secure.Content.Statement.Update)]
    [HttpPost]
    public async Task<ApiResult> UpdateStatement(Statement data)
    {
        try
        {
            var statement = statementRepository.Find(data.Id);
            if (statement == null) return await Task.FromResult(ApiResponse.Error(ErrorHttp.NotFound));

            statement.Mission = data.Mission;
            statement.Vision = data.Vision;
            statement.Expertise = data.Expertise;

            var result = statementRepository.Update(statement);
            if (!result) return await Task.FromResult(ApiResponse.Error(ErrorHttp.DbUpdateError));

            return await Task.FromResult(ApiResponse.Success(result));
        }
        catch (Exception e)
        {
            logger.LogError("error");
            return await Task.FromResult(ApiResponse.Error(ErrorHttp.Error, e));
        }
    }

    [Route(Routes.ApiRoute.Secure.Content.Statement.Delete)]
    [HttpDelete]
    public async Task<ApiResult> DeleteStatement(int id)
    {
        try
        {
            var result = statementRepository.Delete(id);
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

    [Route(Routes.ApiRoute.Secure.Content.Statement.State)]
    [HttpGet]
    public async Task<ApiResult> StateStatement(int id, bool active)
    {
        try
        {
            var result = statementRepository.Status(id, active);
            return await Task.FromResult(result ? ApiResponse.Success(result) : ApiResponse.Error(ErrorHttp.NotFound));
        }
        catch (Exception e)
        {
            logger.LogError("error");
            return await Task.FromResult(ApiResponse.Error(ErrorHttp.Error, e));
        }
    }
}