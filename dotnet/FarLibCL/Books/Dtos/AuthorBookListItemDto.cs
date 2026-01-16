namespace FarLibCL.Books.Dtos;

public class AuthorBookListItemDto
{
    public required Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
}