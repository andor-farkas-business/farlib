using FarLibCL.Stocks.Dtos;

namespace FarLibBLL.Stocks.Services.Interfaces;

public interface IStockService
{
    Task AddAsync(AddStockDto add);
    Task<StockDetailsDto> GetByIdAsync(Guid bookId, Guid distributorId);
    Task<StockListDto> GetAllAsync(StockFilterDto filter);
    Task<BookStockListDto> GetByBookIdAsync(Guid bookId, StockFilterDto filter);
    Task<DistributorStockListDto> GetByDistributorIdAsync(Guid distributorId, StockFilterDto filter);
    Task UpdateAsync(Guid bookId, Guid distributorId, int update);
    Task DeleteAsync(Guid bookId, Guid distributorId);
}