using FarLibPages.ViewComponents.Models;
using Microsoft.AspNetCore.Mvc;

namespace FarLibPages.ViewComponents;

public class PaginationViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(
        string pageName,
        int currentPage,
        int totalPages,
        Dictionary<string, string?> filters
    )
    {
        var pagination = new Pagination()
        {
            PageName = pageName,
            CurrentPage = currentPage,
            TotalPages = totalPages,
            Filters = filters
        };

        return View(pagination);
    }
}