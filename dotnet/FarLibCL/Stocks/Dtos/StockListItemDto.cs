using FarLibCL.Authors.Dtos;

namespace FarLibCL.Stocks.Dtos;

public class StockListItemDto
{
    public required IList<BookAuthorListItemDto> Authors { get; set; }
    public required string BookTitle { get; set; }
    public required string DistributorName { get; set; }
    public required int Amount { get; set; }
}