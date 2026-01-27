using FarLibCL.Authors.Dtos;

namespace FarLibCL.Books.Dtos;

public class BookListItemDto
{
    public required Guid Id { get; set; }
    public required string Title { get; set; }
    public required IList<BookAuthorListItemDto> Authors { get; set; }
}