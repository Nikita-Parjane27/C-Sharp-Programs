using System.Net;
using System.Text.Json;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionMiddleware> _logger;

    public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
    {
        _next   = next;
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
            _logger.LogError(ex, "Exception caught: {Message}", ex.Message);
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        context.Response.ContentType = "application/json";

        int    statusCode;
        string errorType;

        switch (ex)
        {
            case NotFoundException:
                statusCode = (int)HttpStatusCode.NotFound;
                errorType  = "Not Found";
                break;
            case ValidationException:
                statusCode = (int)HttpStatusCode.BadRequest;
                errorType  = "Validation Error";
                break;
            case UnauthorizedException:
                statusCode = (int)HttpStatusCode.Unauthorized;
                errorType  = "Unauthorized";
                break;
            case BusinessException:
                statusCode = (int)HttpStatusCode.UnprocessableEntity;
                errorType  = "Business Rule Violation";
                break;
            default:
                statusCode = (int)HttpStatusCode.InternalServerError;
                errorType  = "Internal Server Error";
                break;
        }

        context.Response.StatusCode = statusCode;

        var response = JsonSerializer.Serialize(new
        {
            StatusCode = statusCode,
            ErrorType  = errorType,
            Message    = ex.Message,
            Timestamp  = DateTime.UtcNow
        });

        return context.Response.WriteAsync(response);
    }
}