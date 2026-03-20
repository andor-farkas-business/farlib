using System.Text.Json;
using System.Text.Json.Serialization;

namespace FarLibCL.Utils;

public static class JsonWrapper
{
    private static readonly JsonSerializerOptions Options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        PropertyNameCaseInsensitive = true,
        WriteIndented = true,
        Converters = { new JsonStringEnumConverter() },
    };

    public static string Serialize(object obj)
    {
        return JsonSerializer.Serialize(obj, Options);
    }

    public static T? Deserialize<T>(string json) where T : class
    {
        return JsonSerializer.Deserialize<T>(json, Options);
    }
}