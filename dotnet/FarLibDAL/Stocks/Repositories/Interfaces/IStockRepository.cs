using FarLibDAL.Stocks.Entities;

namespace FarLibDAL.Stocks.Repositories.Interfaces;

public interface IStockRepository
{
    Task AddAsync(Stock stock);
    Task<Stock?> GetByIdAsync(Guid bookId, Guid distributorId);
    Task<IList<Stock>> GetAllAsync();
    Task<IList<Stock>> GetByBookIdAsync(Guid bookId);
    Task<IList<Stock>> GetByDistributorIdAsync(Guid distributorId);
    Task UpdateAsync(Guid bookId, Guid distributorId, int update);
    Task DeleteAsync(Guid bookId, Guid distributorId);
}