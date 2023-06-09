using Microsoft.AspNetCore.Http.Extensions;

namespace SanctionScanner.API.Middlewares
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly ILogger<CustomExceptionHandlerMiddleware> _logger;
        private readonly RequestDelegate _next;

        public CustomExceptionHandlerMiddleware(ILogger<CustomExceptionHandlerMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception,
                    $"Exception when invoke {context.Request.Method}:{context.Request.GetDisplayUrl()}");
            }
        }
    }
    public static class ErrorMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorWrappingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }
    }
}
