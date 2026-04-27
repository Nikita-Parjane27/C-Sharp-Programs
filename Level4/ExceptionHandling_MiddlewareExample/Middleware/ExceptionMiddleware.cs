// Middleware/ExceptionMiddleware.cs
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

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

    private static Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        context.Response.ContentType = "application/json";

        int statusCode;
        string message;

        switch (ex)
        {
            case ArgumentNullException:
                statusCode = (int)HttpStatusCode.BadRequest;
                message    = "A required argument was null.";
                break;
            case UnauthorizedAccessException:
                statusCode = (int)HttpStatusCode.Unauthorized;
                message    = "You are not authorized.";
                break;
            case KeyNotFoundException:
                statusCode = (int)HttpStatusCode.NotFound;
                message    = "Requested resource not found.";
                break;
            default:
                statusCode = (int)HttpStatusCode.InternalServerError;
                message    = "An unexpected error occurred.";
                break;
        }

        context.Response.StatusCode = statusCode;

        var result = JsonSerializer.Serialize(new
        {
            StatusCode = statusCode,
            Message    = message,
            Detail     = ex.Message
        });

        return context.Response.WriteAsync(result);
    }
}