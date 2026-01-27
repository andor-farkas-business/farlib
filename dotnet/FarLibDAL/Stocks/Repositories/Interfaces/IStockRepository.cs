using FarLibCL.Stocks.Dtos;
using FarLibCL.Stocks.Entities;

namespace FarLibDAL.Stocks.Repositories.Interfaces;

public interface IStockRepository
{
    Task AddAsync(Stock stock);
    Task<Stock?> GetByIdAsync(Guid bookId, Guid distributorId);
    Task<(int, int, IList<Stock>)> GetAllAsync(StockFilterDto filter);
    Task<(int, int, IList<Stock>)> GetByBookIdAsync(Guid bookId, StockFilterDto filter);
    Task<(int, int, IList<Stock>)> GetByDistributorIdAsync(Guid distributorId, StockFilterDto filter);
    Task UpdateAsync(Guid bookId, Guid distributorId, int update);
    Task DeleteAsync(Guid bookId, Guid distributorId);
    Task SaveChangesAsync();
}