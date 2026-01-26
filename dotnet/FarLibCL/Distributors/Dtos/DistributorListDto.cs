namespace FarLibCL.Distributors.Dtos;

public class DistributorListDto
{
    public required IList<DistributorListItemDto> Distributors { get; set; }
    public required int TotalItems { get; set; }
    public required int Page { get; set; }
    public required int TotalPages { get; set; }
}