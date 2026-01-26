using FarLibCL.Authors.Dtos;
using FarLibCL.Authors.Entities;
using FarLibCL.Exceptions;
using FarLibDAL.Authors.Filtering;
using FarLibDAL.Authors.Repositories.Interfaces;
using FarLibDAL.Database;
using Microsoft.EntityFrameworkCore;

namespace FarLibDAL.Authors.Repositories;

public class AuthorRepository(FarLibDbContext dbContext) : IAuthorRepository
{
    public async Task AddAsync(Author author)
    {
        await dbContext.Authors.AddAsync(author);
    }

    public async Task<Author?> GetByIdAsync(Guid id)
    {
        return await dbContext.Authors
            .Include(a => a.Books)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<(int, int, IList<Author>)> GetAllAsync(AuthorFilterDto filter)
    {
        var authors = dbContext.Authors.AsNoTracking();

        var filterPipeline = new AuthorFilterPipeline(authors, filter);
        authors = filterPipeline.Filter();

        return (
            filterPipeline.TotalItems,
            filterPipeline.TotalPages,
            await authors.ToListAsync()
        );
    }

    public async Task UpdateAsync(Guid id, UpdateAuthorDto update)
    {
        var foundAuthor = await dbContext.Authors.FindAsync(id) ??
            throw new ObjectNotFoundException(nameof(Author), nameof(Author.Id), id.ToString());

        if (!string.IsNullOrWhiteSpace(update.Name))
        {
            foundAuthor.Name = update.Name;
        }

        if (!string.IsNullOrWhiteSpace(update.Description))
        {
            foundAuthor.Description = update.Description;
        }
    }

    public async Task DeleteAsync(Guid id)
    {
        var foundAuthor = await dbContext.Authors.FindAsync(id) ??
            throw new ObjectNotFoundException(nameof(Author), nameof(Author.Id), id.ToString());

        dbContext.Authors.Remove(foundAuthor);
    }

    public async Task SaveChangesAsync()
    {
        await dbContext.SaveChangesAsync();
    }
}