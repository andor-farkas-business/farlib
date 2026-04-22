using FarLibBLL.Books.Services.Interfaces;
using FarLibBLL.Stocks.Services.Interfaces;
using FarLibCL.Books.Dtos;
using FarLibCL.Stocks.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FarLibPages.Pages.Books;

public class DetailsModel(
    IBookService bookService,
    IStockService stockService) : PageModel
{
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty(SupportsGet = true)]
    public StockFilterDto StockFilter { get; set; } = default!;

    public BookDetailsDto Book { get; set; } = default!;
    public BookStockListDto Stocks { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Book = await bookService.GetByIdAsync(Id);
        Stocks = await stockService.GetByBookIdAsync(Id, StockFilter);
    }

    public Dictionary<string, string?> MapFiltersToRouteData()
    {
        return new Dictionary<string, string?>
        {
            { "id", Id.ToString() },
            { "pageIndex", StockFilter.PageIndex.ToString() },
            { "pageSize", StockFilter.PageSize.ToString() }
        };
    }
}