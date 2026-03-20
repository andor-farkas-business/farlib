namespace FarLibPages.ViewComponents.Models;

public class Pagination
{
    public required string PageName { get; set; }
    public required int CurrentPage { get; set; }
    public required int TotalPages { get; set; }
    public required Dictionary<string, string?> Filters { get; set; }

    public Dictionary<string, string?> GetRoutePage(int i)
    {
        var result = new Dictionary<string, string?>();

        foreach (var kvp in Filters)
        {
            result.Add(kvp.Key, kvp.Value);
        }

        result["pageIndex"] = i.ToString();

        return result;
    }
}