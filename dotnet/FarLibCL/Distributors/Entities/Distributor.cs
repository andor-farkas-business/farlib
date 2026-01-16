using FarLibCL.Distributors.Enums;
using FarLibCL.Stocks.Entities;

namespace FarLibCL.Distributors.Entities;

public class Distributor
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Address { get; set; }
    public required DistributorType Type { get; set; }

    public IList<Stock> Stocks { get; set; } = [];

}