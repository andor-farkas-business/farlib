namespace FarLibCL.Authors.Dtos;

public class AuthorListItemDto
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
}