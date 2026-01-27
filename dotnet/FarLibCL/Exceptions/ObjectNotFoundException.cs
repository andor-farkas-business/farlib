using System.Net;
using FarLibCL.Exceptions.Enums;

namespace FarLibCL.Exceptions;

public class ObjectNotFoundException(
    string objectType,
    string propertyName,
    string propertyValue) : FarLibException($"The object '{objectType}' with the '{propertyName}':'{propertyValue}' was not found.")
{
    public override ExceptionData ExceptionData => new()
    {
        StatusCode = HttpStatusCode.NotFound,
        ErrorType = ErrorType.ObjectNotFound,
        Error = new Dictionary<string, string>
        {
            { "objectType", objectType },
            { "propertyName", propertyName },
            { "propertyValue", propertyValue }
        }
    };
}