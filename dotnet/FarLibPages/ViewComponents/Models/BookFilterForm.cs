using FarLibCL.Books.Dtos;

namespace FarLibPages.ViewComponents.Models;

public class BookFilterForm
{
    public BookFilterDto Filter { get; set; } = default!;

    public bool IsFiltered()
    {
        return !string.IsNullOrWhiteSpace(Filter.Title) ||
            !string.IsNullOrWhiteSpace(Filter.AuthorName) || 
            (Filter.Category.HasValue && Filter.Category != FarLibCL.Books.Enums.BookCategory.None) ||
            Filter.Type.HasValue;

    }
}