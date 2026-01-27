using FarLibCL.Stocks.Dtos;
using FarLibCL.Stocks.Entities;

namespace FarLibBLL.Stocks.Mappers.Interfaces;

public interface IStockMapper
{
    Stock MapAddDtoToEntity(AddStockDto dto);
    StockDetailsDto MapEntityToDetailsDto(Stock entity);
    StockListItemDto MapEntityToListItemDto(Stock entity);
    DistributorStockListItemDto MapEntityToDistributorStockListItemDto(Stock entity);
    BookStockListItemDto MapEntityToBookStockListItemDto(Stock entity);
}