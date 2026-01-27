using FarLibCL.Authors;
using FarLibCL.Authors.Dtos;
using FarLibCL.Authors.Entities;
using Microsoft.EntityFrameworkCore;

namespace FarLibDAL.Authors.Filtering;

public class AuthorFilterPipeline(IQueryable<Author> authors, AuthorFilterDto filter)
{
    public int TotalItems { get; set; }
    public int TotalPages { get; set; }

    public IQueryable<Author> Filter()
    {
        FilterName();
        Paginate();
        return authors;
    }

    private void FilterName()
    {
        if (string.IsNullOrWhiteSpace(filter.Name))
        {
            return;
        }

        authors = authors.Where(a => EF.Functions.Like(a.Name, $"%{filter.Name}%"));
    }

    private void Paginate()
    {
        if (filter.Page == null || !filter.Page.HasValue)
        {
            filter.Page = 1;
        }

        if (filter.PageSize == null || !filter.PageSize.HasValue)
        {
            filter.PageSize = Constants.DefaultPageSize;
        }

        TotalItems = authors.Count();
        TotalPages = TotalItems / filter.PageSize.Value;
        if (TotalItems % filter.PageSize.Value != 0)
        {
            TotalPages += 1;
        }

        authors = authors
            .OrderBy(a => a.Name)
            .Skip((filter.Page.Value - 1) * filter.PageSize.Value)
            .Take(filter.PageSize.Value);
    }
}