namespace FarLibCL.Stocks.Dtos;

public class DistributorStockListDto
{
    public required IList<DistributorStockListItemDto> Stocks { get; set; }
    public required int TotalItems { get; set; }
    public required int Page { get; set; }
    public required int TotalPages { get; set; }
}