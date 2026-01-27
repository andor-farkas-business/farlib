using FarLibCL.Books.Dtos;
using FarLibCL.Distributors.Dtos;

namespace FarLibCL.Stocks.Dtos;

public class StockDetailsDto
{
    public required BookListItemDto Book { get; set; }
    public required DistributorListItemDto Distributor { get; set; }
    public required int Amount { get; set; }
}