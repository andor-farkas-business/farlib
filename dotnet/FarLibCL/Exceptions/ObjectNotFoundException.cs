namespace FarLibCL.Exceptions;

public class ObjectNotFoundException(
    string objectType,
    string propertyName,
    string propertyValue) : Exception($"The object '{objectType}' with the '{propertyName}':'{propertyValue}' was not found.")
{
}