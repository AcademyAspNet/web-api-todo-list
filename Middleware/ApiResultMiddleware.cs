using System.Net;

namespace MyFirstWebApi.Middleware
{
    public class ApiResultMiddleware
    {
        private readonly RequestDelegate _next;

        public ApiResultMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string? key = context.Request.Query["key"];

            if (key != "abc")
            {
                context.Response.StatusCode = (int) HttpStatusCode.Unauthorized;
                await context.Response.WriteAsync("Incorrect key");

                return;
            }

            await _next.Invoke(context);
        }
    }
}
