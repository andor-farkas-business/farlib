using FarLibCL.Stocks;
using FarLibCL.Stocks.Dtos;
using FarLibCL.Stocks.Entities;

namespace FarLibDAL.Stocks.Filtering;

public class StockFilterPipeline(IQueryable<Stock> stocks, StockFilterDto filter)
{
    public int TotalItems { get; set; }
    public int TotalPages { get; set; }

    public IQueryable<Stock> Filter()
    {
        Paginate();
        return stocks;
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

        TotalItems = stocks.Count();
        TotalPages = TotalItems / filter.PageSize.Value;
        if (TotalItems % filter.PageSize.Value != 0)
        {
            TotalPages += 1;
        }

        stocks = stocks
            .OrderByDescending(s => s.Amount)
            .Skip((filter.PageIndex.Value - 1) * filter.PageSize.Value)
            .Take(filter.PageSize.Value);
    }
}