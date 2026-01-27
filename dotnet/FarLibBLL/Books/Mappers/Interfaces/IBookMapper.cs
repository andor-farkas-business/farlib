using FarLibCL.Books.Dtos;
using FarLibCL.Books.Entities;

namespace FarLibBLL.Books.Mappers.Interfaces;

public interface IBookMapper
{
    Book MapAddDtoToEntity(AddBookDto dto);
    BookDetailsDto MapEntityToDetailsDto(Book entity);
    BookListItemDto MapEntityToListItemDto(Book entity);
}