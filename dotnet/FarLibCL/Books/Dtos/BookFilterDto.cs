using FarLibCL.Books.Enums;

namespace FarLibCL.Books.Dtos;

public class BookFilterDto
{
    public string? Title { get; set; }
    public BookType? Type { get; set; }
    public BookCategory? Category { get; set; }
    public string? AuthorName { get; set; }
    public int? PageIndex { get; set; }
    public int? PageSize { get; set; }
}