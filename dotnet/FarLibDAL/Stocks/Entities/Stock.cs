using FarLibDAL.Books.Entities;
using FarLibDAL.Distributors.Entities;

namespace FarLibDAL.Stocks.Entities;

public class Stock
{
    public Guid BookId { get; set; }
    public Guid DistributorId { get; set; }
    public required int Amount { get; set; }

    public required Book Book { get; set; }
    public required Distributor Distributor { get; set; }
}