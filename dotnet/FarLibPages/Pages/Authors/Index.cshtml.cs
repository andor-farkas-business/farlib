using FarLibBLL.Authors.Services.Interfaces;
using FarLibCL.Authors.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FarLibPages.Pages.Authors;

public class IndexModel(IAuthorService service) : PageModel
{
    [BindProperty(SupportsGet = true)]
    public AuthorFilterDto Filter { get; set; } = default!;

    public AuthorListDto Authors { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Authors = await service.GetAllAsync(Filter);
    }

    public Dictionary<string, string?> MapFiltersToRouteData()
    {
        return new Dictionary<string, string?>
        {
            { "name", Filter.Name },
            { "pageIndex", Filter.PageIndex.ToString() },
            { "pageSize", Filter.PageSize.ToString() }
        };
    }
}