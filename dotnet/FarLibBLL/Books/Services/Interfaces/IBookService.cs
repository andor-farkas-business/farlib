using FarLibCL.Books.Dtos;

namespace FarLibBLL.Books.Services.Interfaces;

public interface IBookService
{
    Task AddAsync(AddBookDto add);
    Task<BookDetailsDto> GetByIdAsync(Guid id);
    Task<BookListDto> GetAllAsync(BookFilterDto filter);
    Task<IList<BookListItemDto>> GetByAuthorAsync(Guid authorId);
    Task UpdateAsync(Guid id, UpdateBookDto update);
    Task DeleteAsync(Guid id);
}