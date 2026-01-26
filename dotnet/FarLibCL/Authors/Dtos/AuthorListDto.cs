namespace FarLibCL.Authors.Dtos;

public class AuthorListDto
{
    public required IList<AuthorListItemDto> Authors { get; set; }
    public required int TotalItems { get; set; }
    public required int Page { get; set; }
    public required int TotalPages { get; set; }
}