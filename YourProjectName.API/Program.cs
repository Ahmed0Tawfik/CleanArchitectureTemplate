using Scalar.AspNetCore;
using YourProjectName.API.Extensions;
using YourProjectName.Application.Extensions;
using YourProjectName.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddOpenApi();



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
}

app.UseHttpsRedirection();

app.HandleException();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
