using Booasacre.Domain.Infrastructure.Db;
using Booasacre.Domain.Injector;
using Booasacre.Domain.Provider.Jwt;
using Booasacre.Domain.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
IdentityModelEventSource.ShowPII = true;
builder.Services.AddDbContext<BooasacreContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("api_booasacre")));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services.AddLogging(); 
builder.Services.AddHttpClient();
builder.Services.AddTransient<DbContext, BooasacreContext>();
builder.Services.AddScoped<Functions>();
builder.Services.RegisterDependenciesBooasacre();
builder.Services.AddSwaggerGen(d =>
{
    d.SwaggerDoc(Consts.SwaggerDocName.Other.Slug, new OpenApiInfo {Title = Consts.SwaggerDocName.Other.Title, Version = Consts.SwaggerDocName.Other.Version, Description = Consts.SwaggerDocName.Other.Description, Contact = new OpenApiContact { Name = Consts.SwaggerDocName.Other.Name }});
    d.SwaggerDoc(Consts.SwaggerDocName.Authenticate.Slug, new OpenApiInfo {Title = Consts.SwaggerDocName.Authenticate.Title, Version = Consts.SwaggerDocName.Authenticate.Version, Description = Consts.SwaggerDocName.Authenticate.Description, Contact = new OpenApiContact { Name = Consts.SwaggerDocName.Authenticate.Name }});
    d.SwaggerDoc(Consts.SwaggerDocName.SecureAdmin.Slug, new OpenApiInfo {Title = Consts.SwaggerDocName.SecureAdmin.Title, Version = Consts.SwaggerDocName.SecureAdmin.Version, Description = Consts.SwaggerDocName.SecureAdmin.Description, Contact = new OpenApiContact { Name = Consts.SwaggerDocName.SecureAdmin.Name }});
    d.SwaggerDoc(Consts.SwaggerDocName.SecureAlert.Slug, new OpenApiInfo {Title = Consts.SwaggerDocName.SecureAlert.Title, Version = Consts.SwaggerDocName.SecureAlert.Version, Description = Consts.SwaggerDocName.SecureAlert.Description, Contact = new OpenApiContact { Name = Consts.SwaggerDocName.SecureAlert.Name }});
    d.SwaggerDoc(Consts.SwaggerDocName.SecureOtp.Slug, new OpenApiInfo {Title = Consts.SwaggerDocName.SecureOtp.Title, Version = Consts.SwaggerDocName.SecureOtp.Version, Description = Consts.SwaggerDocName.SecureOtp.Description, Contact = new OpenApiContact { Name = Consts.SwaggerDocName.SecureOtp.Name }});
});
builder.Services.Configure<SwaggerGeneratorOptions>(options =>
{
    options.InferSecuritySchemes = true;
});
builder.Services.AddAuthorization(auth =>
{
    auth.AddPolicy(JwtBearerDefaults.AuthenticationScheme, new AuthorizationPolicyBuilder()
        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
        .RequireAuthenticatedUser().Build());
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
builder.Services.ConfigureOptions<JwtOptionsSetup>();
builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();
builder.Services.AddMvc()
    .AddJsonOptions(opt =>
    {
        opt.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{ }
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint($"/swagger/{Consts.SwaggerDocName.Other.Slug}/swagger.json", Consts.SwaggerDocName.Other.Name);
    c.SwaggerEndpoint($"/swagger/{Consts.SwaggerDocName.Authenticate.Slug}/swagger.json", Consts.SwaggerDocName.Authenticate.Name);
    c.SwaggerEndpoint($"/swagger/{Consts.SwaggerDocName.SecureAdmin.Slug}/swagger.json", Consts.SwaggerDocName.SecureAdmin.Name);
    c.SwaggerEndpoint($"/swagger/{Consts.SwaggerDocName.SecureAlert.Slug}/swagger.json", Consts.SwaggerDocName.SecureAlert.Name);
    c.SwaggerEndpoint($"/swagger/{Consts.SwaggerDocName.SecureOtp.Slug}/swagger.json", Consts.SwaggerDocName.SecureOtp.Name);
});
app.UseCors(policyBuilder =>
{
    policyBuilder.AllowAnyOrigin();
    policyBuilder.AllowAnyMethod();
    policyBuilder.AllowAnyHeader();
});

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();
