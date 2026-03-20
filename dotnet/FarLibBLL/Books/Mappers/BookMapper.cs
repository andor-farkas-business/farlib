using FarLibBLL.Books.Mappers.Interfaces;
using FarLibCL.Authors.Dtos;
using FarLibCL.Authors.Entities;
using FarLibCL.Books.Dtos;
using FarLibCL.Books.Entities;

namespace FarLibBLL.Books.Mappers;

public class BookMapper : IBookMapper
{
    public Book MapAddDtoToEntity(AddBookDto dto)
    {
        return new Book()
        {
            Id = Guid.Empty,
            Title = dto.Title,
            Description = dto.Description,
            Type = dto.Type,
            Category = dto.Category,
            Authors = [.. dto.AuthorIds.Select(id => new Author
            {
                Id = id
            })]
        };
    }

    public BookDetailsDto MapEntityToDetailsDto(Book entity)
    {
        return new BookDetailsDto()
        {
            Id = entity.Id,
            Title = entity.Title,
            Description = entity.Description,
            Type = entity.Type,
            Category = entity.Category,
            Authors = [.. entity.Authors.Select(a => new BookAuthorListItemDto()
            {
                Id = a.Id,
                Name = a.Name,
            })]
        };
    }

    public BookListItemDto MapEntityToListItemDto(Book entity)
    {
        return new BookListItemDto()
        {
            Id = entity.Id,
            Title = entity.Title,
            Authors = [.. entity.Authors.Select(a => new BookAuthorListItemDto(){
                Id = a.Id,
                Name = a.Name
            })]
        };
    }
}