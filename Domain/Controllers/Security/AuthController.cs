using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Booasacre.Domain.Core.Dto.Request;
using Booasacre.Domain.Core.Dto.Response;
using Booasacre.Domain.Infrastructure.Entity.Booasacre;
using Booasacre.Domain.Infrastructure.Repository.Booasacre;
using Booasacre.Domain.Provider.Jwt;
using Booasacre.Domain.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Booasacre.Domain.Controllers.Security;

 [ApiExplorerSettings(GroupName = Consts.SwaggerDocName.Authenticate.Slug)]
[ApiController]
[Route(Routes.ApiRoute.Security.Auth.Base)]
public class AuthController(
    ILogger<AuthController> logger,
    IOptions<JwtOptions> options,
    IApiUserRepository apiUserRepository,
    IApiUserPermissionRepository apiUserPermissionRepository,
    IApiPermissionRepository apiPermissionRepository)
    : ControllerBase
{
    private readonly JwtOptions _jwtOptions = options.Value;

    [Route(Routes.ApiRoute.Security.Auth.Login)]
    [HttpPost]
    public async Task<ApiResult> Login(AuthRequest authRequest)
    {
        try
        {
            if (
                authRequest.Username == null ||
                authRequest.Password == null ||
                !Functions.IsBase64(authRequest.Username) ||
                !Functions.IsBase64(authRequest.Username)
            ) return await Task.FromResult(ApiResponse.Error(ErrorHttp.NotEncoded));

            authRequest.Username =
                Encoding.UTF8.GetString(Convert.FromBase64String(authRequest.Username?.Trim() ?? string.Empty));
            authRequest.Password =
                Encoding.UTF8.GetString(Convert.FromBase64String(authRequest.Password ?? string.Empty));
            if (authRequest.Username == null) return await Task.FromResult(ApiResponse.Error(ErrorHttp.BadCredentials));

            var user = apiUserRepository.FindByApiKey(authRequest.Username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(authRequest.Password, user.ApiSecret)) return await Task.FromResult(ApiResponse.Error(ErrorHttp.BadCredentials));
            user.UserPermissions = apiUserPermissionRepository.FindByUserId(user.Id);
            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, Guid.NewGuid().ToString("N")),
                new(JwtRegisteredClaimNames.UniqueName, authRequest.Username),
                new(JwtRegisteredClaimNames.Name, authRequest.Username),
                new(JwtRegisteredClaimNames.Email, user.Email ?? ""),
                new(JwtRegisteredClaimNames.NameId, authRequest.Username),
                new(JwtRegisteredClaimNames.GivenName, authRequest.Username),
                new(ClaimTypes.Name, authRequest.Username),
                new(ClaimTypes.NameIdentifier, authRequest.Username)
            };
            user.UserPermissions?.ForEach(userPerm =>
            {
                if (userPerm.FkPermission?.Name != null)
                    claims.Add(new Claim(ClaimTypes.Role, userPerm.FkPermission.Name));
            });
            if (_jwtOptions.SecretKey != null)
            {
                var signingCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)), 
                    SecurityAlgorithms.HmacSha256Signature
                );
                var token = new JwtSecurityToken(
                    _jwtOptions.Issuer, 
                    _jwtOptions.Audience, 
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(user.ApiTokenMinute ?? 1),
                    signingCredentials: signingCredentials
                );
                user.Lastconnect = DateTime.Now;
                apiUserRepository.Update(user);

                return await Task.FromResult(ApiResponse.Success(new JwtResponse
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token), Username = user.ApiKey
                }));
            }
        }
        catch (Exception e)
        {
            logger.LogError("error");
            return await Task.FromResult(ApiResponse.Error(ErrorHttp.Error, e));
        }

        return await Task.FromResult(ApiResponse.Error(ErrorHttp.Error));
    }

    [Route(Routes.ApiRoute.Security.Auth.Register)]
    [HttpPost]
    public async Task<ApiResult> Register(RegisterRequest data)
     {
         try
         {
             data.ApiKey = "yayah.waritay";
             data.Email = "yayah.waritay@njala.edu.sl";
             if (apiUserRepository.FindByApiKey(data.ApiKey) != null)
                 return await Task.FromResult(ApiResponse.Error(ErrorHttp.UsernameUsed));
             if (apiUserRepository.FindByEmail(data.Email) != null)
                 return await Task.FromResult(ApiResponse.Error(ErrorHttp.EmailUsed));
    
             var user = new ApiUser
             {
                 ApiKey = data.ApiKey,
                 Firstname = data.Firstname,
                 Lastname = data.Lastname,
                 Email = data.Email,
                 Channel = data.Channel,
                 ApiSecret = BCrypt.Net.BCrypt.HashPassword(data.ApiSecret),
                 ApiTokenMinute = data.ApiTokenMinute
             };
    
             var result = apiUserRepository.Create(user);
             if (!result) return await Task.FromResult(ApiResponse.Error(ErrorHttp.Error));
             var userSaved = apiUserRepository.FindByApiKey(data.ApiKey);
             if (userSaved == null) return await Task.FromResult(ApiResponse.Error(ErrorHttp.Error));
    
             var userPermissions = new List<string>
             {
                 Consts.Vars.Roles.Admin
             };
             foreach (var userPermission in userPermissions.Select(userPermissionTmp => new ApiUserPermission
                      {
                          FkUser = user,
                          FkPermission = apiPermissionRepository.FindByName(userPermissionTmp)
                      }).Where(userPermission => userPermission.FkPermission != null))
                 apiUserPermissionRepository.Create(userPermission);
    
             return await Task.FromResult(ApiResponse.Success(result));
         }
         catch (Exception e)
         {
             logger.LogError("error");
             return await Task.FromResult(ApiResponse.Error(ErrorHttp.Error, e));
         }
     }
}