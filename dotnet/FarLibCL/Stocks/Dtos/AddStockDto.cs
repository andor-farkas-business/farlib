namespace FarLibCL.Stocks.Dtos;

public class AddStockDto
{
    public required Guid BookId { get; set; }
    public required Guid DistributorId { get; set; }
    public required int Amount { get; set; }
}