using System.Net;
using FarLibCL.Exceptions;
using FarLibCL.Exceptions.Enums;
using FarLibCL.Utils;

namespace FarLibApi.Middlewares;

public class ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleException(context, ex);
        }
    }

    public async Task HandleException(HttpContext context, Exception ex)
    {
        var response = context.Response;
        response.ContentType = "application/json";

        ExceptionData exceptionData = ex switch
        {
            FarLibException farlibEx => farlibEx.ExceptionData,
            _ => new()
            {
                StatusCode = HttpStatusCode.InternalServerError,
                ErrorType = ErrorType.Generic
            },
        };
        response.StatusCode = (int)exceptionData.StatusCode;
        var result = JsonWrapper.Serialize(exceptionData);

        await response.WriteAsync(result);

        logger.LogWarning(
            "Call to {Path} ran into {ErrorType} exception\n'{Message}' -> Handled",
            context.Request.Path,
            exceptionData.ErrorType.ToString(),
            ex.Message);
    }
}