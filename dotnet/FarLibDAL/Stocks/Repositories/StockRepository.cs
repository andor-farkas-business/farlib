using FarLibCL.Exceptions;
using FarLibCL.Stocks.Entities;
using FarLibDAL.Database;
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

    public async Task<IList<Stock>> GetAllAsync()
    {
        return await dbContext.Stocks
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IList<Stock>> GetByBookIdAsync(Guid bookId)
    {
        return await dbContext.Stocks
            .AsNoTracking()
            .Where(s => s.BookId == bookId)
            .ToListAsync();
    }

    public async Task<IList<Stock>> GetByDistributorIdAsync(Guid distributorId)
    {
        return await dbContext.Stocks
            .AsNoTracking()
            .Where(s => s.DistributorId == distributorId)
            .ToListAsync();
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