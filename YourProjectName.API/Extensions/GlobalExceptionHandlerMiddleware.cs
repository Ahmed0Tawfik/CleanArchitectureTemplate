using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text;
using System.Text.Json;

namespace YourProjectName.API.Extensions
{
    public static class GlobalExceptionHandlerMiddleware
    {
        public static void HandleException(
            this IApplicationBuilder app
            )
        {
            app.UseExceptionHandler(o =>
            o.Run(async context =>
            {

                var errorFeatures =
                    context.Features.Get<IExceptionHandlerPathFeature>();

                var exception = errorFeatures.Error;

                if(!(exception is FluentValidation.ValidationException validationsException))
                    throw exception;

                var errors = validationsException.Errors
                    .Select(e => new
                    {
                        Property = e.PropertyName,
                        Message = e.ErrorMessage
                    });


                var errorContent = JsonSerializer.Serialize(errors);

                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(errorContent,Encoding.UTF8);


            }));
        }
    }
}
