using FarLibCL.Books.Entities;
using FarLibCL.Distributors.Entities;

namespace FarLibCL.Stocks.Entities;

public class Stock
{
    public Guid BookId { get; set; }
    public Guid DistributorId { get; set; }
    public required int Amount { get; set; }

    public Book Book { get; set; } = null!;
    public Distributor Distributor { get; set; } = null!;
}