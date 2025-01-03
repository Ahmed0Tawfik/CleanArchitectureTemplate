using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text.Json;
using YourProjectName.Application.APIResponse;
using FluentValidation;

namespace YourProjectName.API.Extensions
{
    public static class GlobalExceptionHandlerMiddleware
    {
        public static void HandleException(
            this IApplicationBuilder app,
            ILogger<ExceptionLogger> logger)
        {
            app.UseExceptionHandler(options =>
            {
                options.Run(async context =>
                {
                    var errorFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                    var exception = errorFeature?.Error;
                    var responseHandler = new APIResponseHandler();

                    if (exception != null)
                    {
                        // Log the exception
                        logger.LogError(exception, "An unhandled exception occurred: {Message}", exception.Message);

                        context.Response.ContentType = "application/json";

                        APIResponse<string> response;

                        switch (exception)
                        {
                            case ValidationException validationException:
                                var validationErrors = validationException.Errors
                                    .Select(e => $"{e.PropertyName}: {e.ErrorMessage}");

                                response = responseHandler.CreateFailureResponse<string>(
                                    validationErrors,
                                    "Validation error occurred",
                                    (int)HttpStatusCode.BadRequest);
                                context.Response.StatusCode = response.StatusCode;
                                break;

                            case UnauthorizedAccessException:
                                response = responseHandler.CreateUnauthorizedResponse<string>("Unauthorized request");
                                context.Response.StatusCode = response.StatusCode;
                                break;

                            case AccessViolationException:
                                response = responseHandler.CreateForbiddenResponse<string>("Access violation occurred");
                                context.Response.StatusCode = response.StatusCode;
                                break;

                            default:
                                response = responseHandler.CreateFailureResponse<string>(
                                    new[] { "An internal server error occurred." },
                                    exception.Message,
                                    (int)HttpStatusCode.InternalServerError);
                                context.Response.StatusCode = response.StatusCode;
                                break;

                        }

                        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                    }
                });
            });
        }
    }
}
