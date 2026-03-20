namespace FarLibCL.Stocks.Dtos;

public class BookStockListDto
{
    public required IList<BookStockListItemDto> Stocks { get; set; }
    public required int TotalItems { get; set; }
    public required int Page { get; set; }
    public required int TotalPages { get; set; }
}