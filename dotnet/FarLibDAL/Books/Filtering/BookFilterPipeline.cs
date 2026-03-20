using FarLibCL.Books;
using FarLibCL.Books.Dtos;
using FarLibCL.Books.Entities;
using Microsoft.EntityFrameworkCore;

namespace FarLibDAL.Books.Filtering;

public class BookFilterPipeline(IQueryable<Book> books, BookFilterDto filter)
{
    public int TotalItems { get; set; }
    public int TotalPages { get; set; }

    public IQueryable<Book> Filter()
    {
        FilterTitle();
        FilterType();
        FilterCategory();
        FilterAuthor();
        Paginate();

        return books;
    }

    private void FilterTitle()
    {
        if (string.IsNullOrWhiteSpace(filter.Title))
        {
            return;
        }

        books = books.Where(b => EF.Functions.Like(b.Title, $"%{filter.Title}%"));
    }

    private void FilterType()
    {
        if (filter.Type == null || !filter.Type.HasValue)
        {
            return;
        }

        books = books.Where(b => b.Type == filter.Type.Value);
    }

    // Contains all flagged categories
    private void FilterCategory()
    {
        if (filter.Category == null || !filter.Category.HasValue)
        {
            return;
        }

        books = books.Where(b => b.Category.HasFlag(filter.Category.Value));
    }

    private void FilterAuthor()
    {
        if (string.IsNullOrWhiteSpace(filter.AuthorName))
        {
            return;
        }

        books = books.Where(b => b.Authors.Any(a => EF.Functions.Like(a.Name, $"%{filter.AuthorName}%")));
    }

    private void Paginate()
    {
        if (filter.PageIndex == null || !filter.PageIndex.HasValue)
        {
            filter.PageIndex = 1;
        }

        if (filter.PageSize == null || !filter.PageSize.HasValue)
        {
            filter.PageSize = Constants.DefaultPageSize;
        }

        TotalItems = books.Count();
        TotalPages = TotalItems / filter.PageSize.Value;
        if (TotalItems % filter.PageSize.Value != 0)
        {
            TotalPages += 1;
        }

        books = books
            .OrderBy(b => b.Title)
            .Skip((filter.PageIndex.Value - 1) * filter.PageSize.Value)
            .Take(filter.PageSize.Value);
    }
}