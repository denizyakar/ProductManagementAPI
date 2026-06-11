using System.Net;
using System.Text.Json;


namespace ProductManagementAPI.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        public readonly RequestDelegate _next;
        public readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred.");

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var response = new
                {
                    StatusCode = context.Response.StatusCode,
                    Message = "An unexpected error occurred."
                };

                var jsonResponse = JsonSerializer.Serialize(response);

                await context.Response.WriteAsync(jsonResponse);

            }
        }


    }
}
