using FarLibCL.Distributors.Dtos;

namespace FarLibCL.Stocks.Dtos;

public class BookStockListItemDto
{
    public required DistributorListItemDto Distributor { get; set; }
    public required int Amount { get; set; }
}