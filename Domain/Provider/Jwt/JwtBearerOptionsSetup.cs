using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Booasacre.Domain.Provider.Jwt;

public class JwtBearerOptionsSetup(IOptions<JwtOptions> options) : IConfigureNamedOptions<JwtBearerOptions>
{
    private readonly JwtOptions _jwtOptions = options.Value;

    public void Configure(string? name, JwtBearerOptions options)
    {
        options.Audience = _jwtOptions.Audience;
        options.IncludeErrorDetails = true;
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        if (_jwtOptions.SecretKey != null)
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _jwtOptions.Issuer,
                ValidAudience = _jwtOptions.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)),
                TokenDecryptionKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey))
            };
    }

    public void Configure(JwtBearerOptions options)
    {
        options.Audience = _jwtOptions.Audience;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = _jwtOptions.Issuer,
            ValidAudience = _jwtOptions.Audience,
            IssuerSigningKey = new RsaSecurityKey(new RSACryptoServiceProvider(2048))
        };
    }
}