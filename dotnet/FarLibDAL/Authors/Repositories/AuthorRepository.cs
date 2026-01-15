using FarLibCL.Authors.Dtos;
using FarLibDAL.Authors.Entities;
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

    public async Task<IList<Author>> GetAllAsync()
    {
        return await dbContext.Authors
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task UpdateAsync(Guid id, UpdateAuthorDto update)
    {
        var foundAuthor = await dbContext.Authors.FindAsync(id);

        if (foundAuthor == null)
        {
            return;
        }

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
        var foundAuthor = await dbContext.Authors.FindAsync(id);

        if (foundAuthor == null)
        {
            return;
        }

        dbContext.Authors.Remove(foundAuthor);
    }
}