using FarLibBLL.Books.Services.Interfaces;
using FarLibCL.Books.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FarLibPages.Pages.Books;

public class IndexModel(IBookService service) : PageModel
{
    [BindProperty(SupportsGet = true)]
    public BookFilterDto Filter { get; set; } = default!;

    public BookListDto Books { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Books = await service.GetAllAsync(Filter);
    }

    public Dictionary<string, string?> MapFiltersToRouteData()
    {
        return new Dictionary<string, string?>
        {
            { "title", Filter.Title },
            { "type", Filter.Type.ToString() },
            { "category", Filter.Category.ToString() },
            { "authorName", Filter.AuthorName },
            { "pageIndex", Filter.PageIndex.ToString() },
            { "pageSize", Filter.PageSize.ToString() }
        };
    }
}