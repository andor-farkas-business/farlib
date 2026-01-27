using FarLibCL.Books.Dtos;
using FarLibCL.Books.Entities;

namespace FarLibDAL.Books.Repositories.Interfaces;

public interface IBookRepository
{
    Task AddAsync(Book book);
    Task<Book?> GetByIdAsync(Guid id);
    Task<(int, int, IList<Book>)> GetAllAsync(BookFilterDto filter);
    Task<IList<Book>> GetByAuthorAsync(Guid authorId);
    Task UpdateAsync(Guid id, UpdateBookDto update);
    Task DeleteAsync(Guid id);
    Task SaveChangesAsync();
}