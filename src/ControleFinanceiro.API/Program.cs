using ControleFinanceiro.API.Configuration;
using ControleFinanceiro.API.Extensions;

//========================================== Environment Configure ===============================================/
var builder = WebApplication.CreateBuilder(args);
builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();
//================================================ End ========================================================/


builder.Services.AddSecurityConfig();
builder.Services.AddDbContextsConfig(builder.Configuration);
builder.AddCorsConfig();
builder.Services.AddDocumentationConfig(builder.Configuration);
builder.Services.ResolveDependencies(builder.Configuration);



var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseConfigureDevEnvironmentConfig();
}
app.UseCors(CorsPolicy.CorsPolicyName);
app.UseSecurityConfig();
app.UseIdentityEndPointsConfig();
app.Run();
