using Scalar.AspNetCore;
using Serilog.Core;
using YourProjectName.API;
using YourProjectName.API.Extensions;
using YourProjectName.Application.Extensions;
using YourProjectName.Infrastructure.Extensions;
using YourProjectName.Infrastructure.Logging;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Host.SerilogConfiguration();

builder.Services
    .AddApplicationServices()
    .AddJwtAuthentication(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration)
    .AddMediatrServices();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(); // Swagger Althernative (BETTER)
    builder.Configuration.AddUserSecrets<Program>();
}

app.UseHttpsRedirection();

var logger = app.Services.GetRequiredService<ILogger<ExceptionLogger>>();

app.HandleException(logger);

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
