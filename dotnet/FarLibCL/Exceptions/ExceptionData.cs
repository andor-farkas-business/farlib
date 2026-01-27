using System.Net;
using FarLibCL.Exceptions.Enums;

namespace FarLibCL.Exceptions;

public class ExceptionData
{
    public required HttpStatusCode StatusCode { get; set; }
    public required ErrorType ErrorType { get; set; }
    public Dictionary<string, string>? Error { get; set; }
}