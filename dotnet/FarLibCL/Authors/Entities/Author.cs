using FarLibCL.Books.Entities;

namespace FarLibCL.Authors.Entities;

public class Author
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }

    public IList<Book> Books { get; set; } = [];
}