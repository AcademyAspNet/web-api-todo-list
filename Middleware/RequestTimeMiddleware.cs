using System.Diagnostics;

namespace MyFirstWebApi.Middleware
{
    public class RequestTimeMiddleware
    {
        private const long MAX_REPONSE_TIME = 500;

        private readonly RequestDelegate _next;
        private readonly ILogger<RequestTimeMiddleware> _logger;

        public RequestTimeMiddleware(RequestDelegate next, ILogger<RequestTimeMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            await _next.Invoke(context);

            stopwatch.Stop();
            long deltaTime = stopwatch.ElapsedMilliseconds;

            if (deltaTime > MAX_REPONSE_TIME)
            {
                _logger.LogWarning($"Обработка запроса занимает дольше обычного: {deltaTime} (допустимо до {MAX_REPONSE_TIME} мсек)");
                return;
            }

            _logger.LogInformation($"Время обработки запроса: {deltaTime} мсек");
        }
    }
}
