using FarLibCL.Books.Dtos;
using FarLibPages.ViewComponents.Models;
using Microsoft.AspNetCore.Mvc;

namespace FarLibPages.ViewComponents;

public class BookFilterFormViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(BookFilterDto filter)
    {
        var bookFilterForm = new BookFilterForm
        {
            Filter = filter
        };

        return View(bookFilterForm);
    }
}