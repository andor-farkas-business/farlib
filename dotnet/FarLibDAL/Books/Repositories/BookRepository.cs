using FarLibCL.Books.Dtos;
using FarLibCL.Books.Entities;
using FarLibCL.Exceptions;
using FarLibDAL.Books.Filtering;
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

    public async Task<(int, int, IList<Book>)> GetAllAsync(BookFilterDto filter)
    {
        var books = dbContext.Books
            .Include(b => b.Authors)
            .AsNoTracking();

        var filterPipeline = new BookFilterPipeline(books, filter);
        books = filterPipeline.Filter();
        return (
            filterPipeline.TotalItems,
            filterPipeline.TotalPages,
            await books
            .ToListAsync());
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

    public async Task SaveChangesAsync()
    {
        await dbContext.SaveChangesAsync();
    }
}