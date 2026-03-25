using API_Tecnywe.Exceptions;
using System.Net;
using System.Text.Json;

namespace API_Tecnywe.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode statusCode;
            string message = exception.Message;

            switch (exception)
            {
                case NotFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    break;
                case BadRequestException:
                    statusCode = HttpStatusCode.BadRequest;
                    break;
                case UnauthorizedAccessException:
                    statusCode = HttpStatusCode.Unauthorized;
                    break;
                default:
                    statusCode = HttpStatusCode.InternalServerError;
                    break;
            }

            var response = new
            {
                StatusCode = (int)statusCode,
                Message = message
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
