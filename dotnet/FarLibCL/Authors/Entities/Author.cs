using FarLibCL.Books.Entities;

namespace FarLibCL.Authors.Entities;

public class Author
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }

    public IList<Book> Books { get; set; } = [];
}