using FarLibCL.Authors.Entities;
using FarLibCL.Books.Enums;
using FarLibCL.Stocks.Entities;

namespace FarLibCL.Books.Entities;

public class Book
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required BookType Type { get; set; }
    public required BookCategory Category { get; set; }

    public IList<Author> Authors { get; set; } = [];
    public IList<Stock> Stocks { get; set; } = [];
}