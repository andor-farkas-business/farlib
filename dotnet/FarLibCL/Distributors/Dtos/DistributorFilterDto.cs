using FarLibCL.Distributors.Enums;

namespace FarLibCL.Distributors.Dtos;

public class DistributorFilterDto
{
    public string? Name { get; set; }
    public DistributorType? Type { get; set; }
    public int? PageIndex { get; set; }
    public int? PageSize { get; set; }
}