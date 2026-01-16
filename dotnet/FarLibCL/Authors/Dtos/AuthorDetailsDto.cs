using FarLibCL.Books.Dtos;

namespace FarLibCL.Authors.Dtos;

public class AuthorDetailsDto
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required IList<AuthorBookListItemDto> Books { get; set; }
}