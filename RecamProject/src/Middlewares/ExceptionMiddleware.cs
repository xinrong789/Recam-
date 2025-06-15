using System.Text.Json;                          // 用于 JsonSerializer.Serialize
using System.Threading.Tasks;                   // 用于 Task
using Microsoft.AspNetCore.Http;                // 用于 HttpContext, RequestDelegate
using Microsoft.Extensions.Logging;             // 用于 ILogger
using FluentValidation;                         // 用于 ValidationException
using RecamProject.Utilities;
using RecamProject.Exceptions;           // 用于自定义异常类

namespace RecamProject.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
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
                _logger.LogError(ex, "An unhandled exception occurred");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            var response = exception switch
            {
                ValidationException validationEx => ApiResponse<object>.Fail(
                    validationEx.Message,
                    "VALIDATION_ERROR"
                ),
                NotFoundException notFoundEx => ApiResponse<object>.Fail(
                    notFoundEx.Message,
                    "NOT_FOUND"
                ),
                UnauthorizedException unauthorizedEx => ApiResponse<object>.Fail(
                    unauthorizedEx.Message,
                    "UNAUTHORIZED"
                ),
                _ => ApiResponse<object>.Fail(
                    "An error occurred while processing your request",
                    "INTERNAL_ERROR"
                )
            };

            context.Response.StatusCode = GetStatusCode(exception);
            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }

        private static int GetStatusCode(Exception exception) => exception switch
        {
            ValidationException => 400,
            NotFoundException => 404,
            UnauthorizedException => 401,
            _ => 500
        };
    }
}