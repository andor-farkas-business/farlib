namespace FarLibCL.Stocks.Dtos;

public class StockListDto
{
    public required IList<StockListItemDto> Stocks { get; set; }
    public required int TotalItems { get; set; }
    public required int Page { get; set; }
    public required int TotalPages { get; set; }
}