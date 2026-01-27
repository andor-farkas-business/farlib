using FarLibCL.Distributors.Enums;

namespace FarLibCL.Distributors.Dtos;

public class DistributorListItemDto
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required DistributorType Type { get; set; }
}