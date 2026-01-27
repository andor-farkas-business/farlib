using FarLibCL.Exceptions;
using FarLibCL.Stocks.Dtos;
using FarLibCL.Stocks.Entities;
using FarLibDAL.Database;
using FarLibDAL.Stocks.Filtering;
using FarLibDAL.Stocks.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FarLibDAL.Stocks.Repositories;

public class StockRepository(FarLibDbContext dbContext) : IStockRepository
{
    public async Task AddAsync(Stock stock)
    {
        await dbContext.Stocks.AddAsync(stock);
    }

    public async Task<Stock?> GetByIdAsync(Guid bookId, Guid distributorId)
    {
        return await dbContext.Stocks
            .Include(s => s.Book)
            .Include(s => s.Distributor)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.BookId == bookId && x.DistributorId == distributorId);
    }

    public async Task<(int, int, IList<Stock>)> GetAllAsync(StockFilterDto filter)
    {
        var stocks = dbContext.Stocks
            .AsNoTracking();

        var filterPipeline = new StockFilterPipeline(stocks, filter);

        stocks = filterPipeline.Filter();

        return (
            filterPipeline.TotalItems,
            filterPipeline.TotalPages,
            await stocks.ToListAsync()
        );
    }

    public async Task<(int, int, IList<Stock>)> GetByBookIdAsync(Guid bookId, StockFilterDto filter)
    {
        var stocks = dbContext.Stocks
            .Include(s => s.Distributor)
            .AsNoTracking()
            .Where(s => s.BookId == bookId);

        var filterPipeline = new StockFilterPipeline(stocks, filter);

        stocks = filterPipeline.Filter();

        return (
            filterPipeline.TotalItems,
            filterPipeline.TotalPages,
            await stocks.ToListAsync()
        );
    }

    public async Task<(int, int, IList<Stock>)> GetByDistributorIdAsync(Guid distributorId, StockFilterDto filter)
    {
        var stocks = dbContext.Stocks
            .Include(s => s.Book)
            .AsNoTracking()
            .Where(s => s.DistributorId == distributorId);

        var filterPipeline = new StockFilterPipeline(stocks, filter);

        stocks = filterPipeline.Filter();

        return (
            filterPipeline.TotalItems,
            filterPipeline.TotalPages,
            await stocks.ToListAsync()
        );
    }

    public async Task UpdateAsync(Guid bookId, Guid distributorId, int update)
    {
        var foundStock = await dbContext.Stocks.FindAsync(bookId, distributorId) ??
            throw new ObjectNotFoundException(
                nameof(Stock),
                $"{nameof(Stock.BookId)}, {nameof(Stock.DistributorId)}",
                $"{bookId}, {distributorId}");

        foundStock.Amount = update;
    }

    public async Task DeleteAsync(Guid bookId, Guid distributorId)
    {
        var foundStock = await dbContext.Stocks.FindAsync(bookId, distributorId) ??
            throw new ObjectNotFoundException(
                nameof(Stock),
                $"{nameof(Stock.BookId)}, {nameof(Stock.DistributorId)}",
                $"{bookId}, {distributorId}");

        dbContext.Stocks.Remove(foundStock);
    }

    public async Task SaveChangesAsync()
    {
        await dbContext.SaveChangesAsync();
    }
}