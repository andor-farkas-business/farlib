using FarLibCL.Books.Enums;
using FarLibDAL.Authors.Entities;
using FarLibDAL.Stocks.Entities;

namespace FarLibDAL.Books.Entities;

public class Book
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required BookType Type { get; set; }
    public required BookCategory Category { get; set; }

    public required IList<Author> Authors { get; set; }
    public IList<Stock> Stocks { get; set; } = [];
}