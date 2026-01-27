using FarLibCL.Books.Enums;

namespace FarLibCL.Books.Dtos;

public class UpdateBookDto
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public BookType? Type { get; set; }
    public BookCategory? Category { get; set; }
}