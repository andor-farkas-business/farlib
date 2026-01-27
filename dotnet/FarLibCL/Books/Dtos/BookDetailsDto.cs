using FarLibCL.Authors.Dtos;
using FarLibCL.Books.Enums;

namespace FarLibCL.Books.Dtos;

public class BookDetailsDto
{
    public required Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required BookType Type { get; set; }
    public required BookCategory Category { get; set; }
    public required IList<BookAuthorListItemDto> Authors { get; set; }
}