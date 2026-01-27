using FarLibCL.Distributors.Enums;

namespace FarLibCL.Distributors.Dtos;

public class AddDistributorDto
{
    public required string Name { get; set; }
    public required string Address { get; set; }
    public required DistributorType Type { get; set; }
}