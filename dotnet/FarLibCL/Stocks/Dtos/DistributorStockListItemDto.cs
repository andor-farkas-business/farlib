using FarLibCL.Books.Dtos;

namespace FarLibCL.Stocks.Dtos;

public class DistributorStockListItemDto
{
    public required BookListItemDto Book { get; set; }
    public required int Amount { get; set; }
}