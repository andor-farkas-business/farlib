namespace FarLibCL.Books.Dtos;

public class BookListDto
{
    public required IList<BookListItemDto> Books { get; set; }
    public required int TotalItems { get; set; }
    public required int Page { get; set; }
    public required int TotalPages { get; set; }
}