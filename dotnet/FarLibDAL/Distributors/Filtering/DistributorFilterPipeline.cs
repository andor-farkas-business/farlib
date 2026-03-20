using System.ComponentModel;
using FarLibCL.Distributors;
using FarLibCL.Distributors.Dtos;
using FarLibCL.Distributors.Entities;
using Microsoft.EntityFrameworkCore;

namespace FarLibDAL.Distributors.Filtering;

public class DistributorFilterPipeline(IQueryable<Distributor> distributors, DistributorFilterDto filter)
{
    public int TotalItems { get; set; }
    public int TotalPages { get; set; }

    public IQueryable<Distributor> Filter()
    {
        FilterName();
        FilterType();
        Paginate();
        return distributors;
    }

    public void FilterName()
    {
        if (string.IsNullOrWhiteSpace(filter.Name))
        {
            return;
        }

        distributors = distributors.Where(d => EF.Functions.Like(d.Name, $"%{filter.Name}%"));
    }

    public void FilterType()
    {
        if (filter.Type == null || !filter.Type.HasValue)
        {
            return;
        }

        distributors = distributors.Where(d => d.Type == filter.Type);
    }

    public void Paginate()
    {
        if (filter.PageIndex == null || !filter.PageIndex.HasValue)
        {
            filter.PageIndex = 1;
        }

        if (filter.PageSize == null || !filter.PageSize.HasValue)
        {
            filter.PageSize = Constants.DefaultPageSize;
        }

        TotalItems = distributors.Count();
        TotalPages = TotalItems / filter.PageSize.Value;
        if (TotalItems % filter.PageSize.Value != 0)
        {
            TotalPages += 1;
        }

        distributors = distributors
            .OrderBy(d => d.Name)
            .Skip((filter.PageIndex.Value - 1) * filter.PageSize.Value)
            .Take(filter.PageSize.Value);
    }
}