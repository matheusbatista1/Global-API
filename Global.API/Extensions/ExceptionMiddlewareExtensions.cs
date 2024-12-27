using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;

namespace Global_api.Extensions;

public static class ExceptionMiddlewareExtensions
{
    public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder app, IHostEnvironment env)
    {
        app.UseExceptionHandler(errorApp =>
        {
            errorApp.Run(async context =>
            {
                context.Response.ContentType = "application/json";

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    var exception = contextFeature.Error;

                    var statusCode = exception switch
                    {
                        ArgumentNullException => StatusCodes.Status400BadRequest,
                        UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
                        KeyNotFoundException => StatusCodes.Status404NotFound,
                        _ => StatusCodes.Status500InternalServerError
                    };

                    context.Response.StatusCode = statusCode;

                    var response = new
                    {
                        StatusCode = statusCode,
                        Message = statusCode switch
                        {
                            StatusCodes.Status400BadRequest => "Invalid input provided.",
                            StatusCodes.Status401Unauthorized => "You are not authorized to access this resource.",
                            StatusCodes.Status404NotFound => "The requested resource was not found.",
                            StatusCodes.Status500InternalServerError => "An unexpected error occurred.",
                            _ => "An error occurred."
                        },
                        Detail = env.IsDevelopment() ? exception.Message : null
                    };

                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                }
            });
        });

        return app;
    }
}