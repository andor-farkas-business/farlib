using FarLibBLL.Stocks.Mappers.Interfaces;
using FarLibBLL.Stocks.Services.Interfaces;
using FarLibCL.Exceptions;
using FarLibCL.Stocks.Dtos;
using FarLibCL.Stocks.Entities;
using FarLibDAL.Stocks.Repositories.Interfaces;

namespace FarLibBLL.Stocks.Services;

public class StockService(IStockRepository repostiory, IStockMapper mapper) : IStockService
{
    public async Task AddAsync(AddStockDto add)
    {
        var entity = mapper.MapAddDtoToEntity(add);

        await repostiory.AddAsync(entity);
        await repostiory.SaveChangesAsync();
    }

    public async Task<StockDetailsDto> GetByIdAsync(Guid bookId, Guid distributorId)
    {
        var entity = await repostiory.GetByIdAsync(bookId, distributorId) ??
            throw new ObjectNotFoundException(
                nameof(Stock),
                $"{nameof(Stock.BookId)}, {nameof(Stock.DistributorId)}",
                $"{bookId}, {distributorId}");

        return mapper.MapEntityToDetailsDto(entity);
    }

    public async Task<StockListDto> GetAllAsync(StockFilterDto filter)
    {
        var (totalItems, totalPages, entities) = await repostiory.GetAllAsync(filter);

        return new StockListDto
        {
            Stocks = [.. entities.Select(mapper.MapEntityToListItemDto)],
            TotalItems = totalItems,
            Page = filter.Page!.Value,
            TotalPages = totalPages,
        };
    }

    public async Task<BookStockListDto> GetByBookIdAsync(Guid bookId, StockFilterDto filter)
    {
        var (totalItems, totalPages, entities) = await repostiory.GetByBookIdAsync(bookId, filter);

        return new BookStockListDto
        {
            Stocks = [.. entities.Select(mapper.MapEntityToBookStockListItemDto)],
            TotalItems = totalItems,
            Page = filter.Page!.Value,
            TotalPages = totalPages,
        };
    }

    public async Task<DistributorStockListDto> GetByDistributorIdAsync(Guid distributorId, StockFilterDto filter)
    {
        var (totalItems, totalPages, entities) = await repostiory.GetByDistributorIdAsync(distributorId, filter);

        return new DistributorStockListDto
        {
            Stocks = [.. entities.Select(mapper.MapEntityToDistributorStockListItemDto)],
            TotalItems = totalItems,
            Page = filter.Page!.Value,
            TotalPages = totalPages,
        };
    }

    public async Task UpdateAsync(Guid bookId, Guid distributorId, int update)
    {
        await repostiory.UpdateAsync(bookId, distributorId, update);
        await repostiory.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid bookId, Guid distributorId)
    {
        await repostiory.DeleteAsync(bookId, distributorId);
        await repostiory.SaveChangesAsync();
    }
}