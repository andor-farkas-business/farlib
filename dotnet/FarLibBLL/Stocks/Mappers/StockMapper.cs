using FarLibBLL.Stocks.Mappers.Interfaces;
using FarLibCL.Authors.Dtos;
using FarLibCL.Books.Dtos;
using FarLibCL.Distributors.Dtos;
using FarLibCL.Stocks.Dtos;
using FarLibCL.Stocks.Entities;

namespace FarLibBLL.Stocks.Mappers;

public class StockMapper : IStockMapper
{
    public Stock MapAddDtoToEntity(AddStockDto dto)
    {
        return new Stock
        {
            BookId = dto.BookId,
            DistributorId = dto.DistributorId,
            Amount = dto.Amount,
        };
    }

    public StockDetailsDto MapEntityToDetailsDto(Stock entity)
    {
        return new StockDetailsDto
        {
            Book = new BookListItemDto
            {
                Id = entity.Book.Id,
                Title = entity.Book.Title,
                Authors = [.. entity.Book.Authors.Select(a => new BookAuthorListItemDto
                {
                    Id = a.Id,
                    Name = a.Name,
                })]
            },
            Distributor = new DistributorListItemDto
            {
                Id = entity.Distributor.Id,
                Name = entity.Distributor.Name,
                Type = entity.Distributor.Type,
            },
            Amount = entity.Amount,
        };
    }

    public StockListItemDto MapEntityToListItemDto(Stock entity)
    {
        return new StockListItemDto
        {
            Authors = [.. entity.Book.Authors.Select(a => new BookAuthorListItemDto
            {
                Id = a.Id,
                Name = a.Name,
            })],
            BookTitle = entity.Book.Title,
            DistributorName = entity.Distributor.Name,
            Amount = entity.Amount
        };
    }

    public BookStockListItemDto MapEntityToBookStockListItemDto(Stock entity)
    {
        return new BookStockListItemDto
        {
            Distributor = new DistributorListItemDto
            {
                Id = entity.Distributor.Id,
                Name = entity.Distributor.Name,
                Type = entity.Distributor.Type,
            },
            Amount = entity.Amount
        };
    }

    public DistributorStockListItemDto MapEntityToDistributorStockListItemDto(Stock entity)
    {
        return new DistributorStockListItemDto
        {
            Book = new BookListItemDto
            {
                Id = entity.Book.Id,
                Title = entity.Book.Title,
                Authors = [.. entity.Book.Authors.Select(a => new BookAuthorListItemDto
                {
                    Id = a.Id,
                    Name = a.Name,
                })]
            },
            Amount = entity.Amount
        };
    }
}