using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using System.Net;

namespace CrossCuttingConcerns.Exceptions;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
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
            await HandleExceptionAsync(context, exception);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        if (exception.GetType() == typeof(BusinessException)) return CreateBusinessException(context, exception);
        if (exception.GetType() == typeof(ValidationException)) return CreateValidationException(context, exception);
        return CreateInternalException(context, exception);
    }

    private static Task CreateBusinessException(HttpContext context, Exception exception)
    {
        context.Response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);
        return context.Response.WriteAsync(new BusinessProblemDetails
        {
            Status = StatusCodes.Status400BadRequest,
            Type = "Business",
            Title = "Business Exception",
            Detail = exception.Message
        }.ToString());
    }
    private static Task CreateValidationException(HttpContext context, Exception exception)
    {
        context.Response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);
        object errors = ((ValidationException)exception).Errors;

        return context.Response.WriteAsync(new ValidationProblemDetails
        {
            Status = StatusCodes.Status400BadRequest,
            Type = "Validation",
            Title = "Validation Error(s)",
            Errors = errors
        }.ToString());
    }
    private static Task CreateInternalException(HttpContext context, Exception exception)
    {
        context.Response.StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError);

        return context.Response.WriteAsync(new ProblemDetails
        {
            Status = StatusCodes.Status500InternalServerError,
            Type = "Internal",
            Title = "Internal exception",
            Detail = exception.Message,
            Instance = ""
        }.ToString());
    }
}