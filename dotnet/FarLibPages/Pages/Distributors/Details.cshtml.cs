using FarLibBLL.Distributors.Services.Interfaces;
using FarLibBLL.Stocks.Services.Interfaces;
using FarLibCL.Distributors.Dtos;
using FarLibCL.Stocks.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FarLibPages.Pages.Distributors;

public class DetailsModel(
    IDistributorService distributorService,
    IStockService stockService) : PageModel
{
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }
    [BindProperty(SupportsGet = true)]
    public StockFilterDto StockFilter { get; set; } = default!;

    public DistributorDetailsDto Distributor { get; set; } = default!;
    public DistributorStockListDto Stocks { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Distributor = await distributorService.GetByIdAsync(Id);
        Stocks = await stockService.GetByDistributorIdAsync(Id, StockFilter);
    }
}