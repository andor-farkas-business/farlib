using FarLibCL.Books.Dtos;
using FarLibCL.Books.Entities;
using FarLibCL.Books.Enums;
using FarLibCL.Exceptions;
using FarLibDAL.Books.Repositories.Interfaces;
using FarLibDAL.Database;
using Microsoft.EntityFrameworkCore;

namespace FarLibDAL.Books.Repositories;

public class BookRepository(FarLibDbContext dbContext) : IBookRepository
{
    public async Task AddAsync(Book book)
    {
        await dbContext.AddAsync(book);
    }

    public async Task<Book?> GetByIdAsync(Guid id)
    {
        return await dbContext.Books
            .Include(b => b.Authors)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IList<Book>> GetAllAsync()
    {
        return await dbContext.Books
            .Include(b => b.Authors)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IList<Book>> GetByTypeAsync(BookType type)
    {
        return await dbContext.Books
            .Include(b => b.Authors)
            .AsNoTracking()
            .Where(b => b.Type == type)
            .ToListAsync();
    }

    // Contains all flagged categories
    public async Task<IList<Book>> GetByCategoryAsync(BookCategory category)
    {
        return await dbContext.Books
            .Include(b => b.Authors)
            .AsNoTracking()
            .Where(b => b.Category.HasFlag(category))
            .ToListAsync();
    }

    public async Task<IList<Book>> GetByAuthorAsync(Guid authorId)
    {
        return await dbContext.Books
            .Include(b => b.Authors)
            .AsNoTracking()
            .Where(b => b.Authors.Any(x => x.Id == authorId))
            .ToListAsync();
    }

    public async Task UpdateAsync(Guid id, UpdateBookDto update)
    {
        var foundBook = await dbContext.Books.FindAsync(id) ??
            throw new ObjectNotFoundException(nameof(Book), nameof(Book.Id), id.ToString());

        if (!string.IsNullOrWhiteSpace(update.Title))
        {
            foundBook.Title = update.Title;
        }

        if (!string.IsNullOrWhiteSpace(update.Description))
        {
            foundBook.Description = update.Description;
        }

        if (update.Type != null && update.Type.HasValue)
        {
            foundBook.Type = update.Type.Value;
        }

        if (update.Category != null && update.Category.HasValue)
        {
            foundBook.Category = update.Category.Value;
        }
    }

    public async Task DeleteAsync(Guid id)
    {
        var foundBook = await dbContext.Books.FindAsync(id) ??
            throw new ObjectNotFoundException(nameof(Book), nameof(Book.Id), id.ToString());
            
        dbContext.Books.Remove(foundBook);
    }
}