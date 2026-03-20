using FarLibBLL.Authors.Services.Interfaces;
using FarLibCL.Authors.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FarLibPages.Pages.Authors;

public class DetailsModel(IAuthorService service) : PageModel
{
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; } 

    public AuthorDetailsDto Author { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Author = await service.GetByIdAsync(Id);
    }
}