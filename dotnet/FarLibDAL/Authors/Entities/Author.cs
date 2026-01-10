using FarLibDAL.Books.Entities;

namespace FarLibDAL.Authors.Entities;

public class Author
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }

    public required IList<Book> Books { get; set; }
}