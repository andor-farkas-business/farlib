using System.Net;
using FarLibCL.Exceptions.Enums;

namespace FarLibCL.Exceptions;

public class FarLibException(string message) : Exception(message)
{
    public virtual ExceptionData ExceptionData => new()
    {
        StatusCode = HttpStatusCode.InternalServerError,
        ErrorType = ErrorType.Generic,
    };
}