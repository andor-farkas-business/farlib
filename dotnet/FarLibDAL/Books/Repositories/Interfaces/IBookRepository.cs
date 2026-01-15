using FarLibCL.Books.Dtos;
using FarLibCL.Books.Enums;
using FarLibDAL.Books.Entities;

namespace FarLibDAL.Books.Repositories.Interfaces;

public interface IBookRepository
{
    Task AddAsync(Book book);
    Task<Book?> GetByIdAsync(Guid id);
    Task<IList<Book>> GetAllAsync();
    Task<IList<Book>> GetByTypeAsync(BookType type);
    Task<IList<Book>> GetByCategoryAsync(BookCategory category);
    Task<IList<Book>> GetByAuthorAsync(Guid authorId);
    Task UpdateAsync(Guid id, UpdateBookDto update);
    Task DeleteAsync(Guid id);
}