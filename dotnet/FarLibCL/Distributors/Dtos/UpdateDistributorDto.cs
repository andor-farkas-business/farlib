using FarLibCL.Distributors.Enums;

namespace FarLibCL.Distributors.Dtos;

public class UpdateDistributorDto
{
    public string? Name { get; set; }
    public string? Address { get; set; }
    public DistributorType? Type { get; set; }
}