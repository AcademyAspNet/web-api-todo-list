using MyFirstWebApi.Helpers;
using MyFirstWebApi.Models.Response;
using System.Net;

namespace MyFirstWebApi.Middleware
{
    public class GlobalErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalErrorHandlerMiddleware> _logger;

        public GlobalErrorHandlerMiddleware(RequestDelegate next, ILogger<GlobalErrorHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception exception)
            {
                HandleException(exception);

                context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;

                ApiResult<object> apiResult = ApiHelper.Fail("Internal server error", HttpStatusCode.InternalServerError);
                await context.Response.WriteAsJsonAsync(apiResult);
            }
        }

        private void HandleException(Exception exception)
        {
            _logger.LogError($"Exception: {exception.Message}");
        }
    }
}
