using FarLibCL.Distributors.Dtos;
using FarLibCL.Distributors.Entities;
using FarLibCL.Distributors.Enums;
using FarLibCL.Exceptions;
using FarLibDAL.Database;
using FarLibDAL.Distributors.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FarLibDAL.Distributors.Repositories;

public class DistributorRepository(FarLibDbContext dbContext) : IDistributorRepository
{
    public async Task AddAsync(Distributor distributor)
    {
        await dbContext.Distributors.AddAsync(distributor);
    }

    public async Task<Distributor?> GetByIdAsync(Guid id)
    {
        return await dbContext.Distributors
            .Include(d => d.Stocks)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IList<Distributor>> GetAllAsync()
    {
        return await dbContext.Distributors
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IList<Distributor>> GetByTypeAsync(DistributorType type)
    {
        return await dbContext.Distributors
            .AsNoTracking()
            .Where(d => d.Type == type)
            .ToListAsync();
    }

    public async Task UpdateAsync(Guid id, UpdateDistributorDto update)
    {
        var foundDistributor = await dbContext.Distributors.FindAsync(id) ??
            throw new ObjectNotFoundException(nameof(Distributor), nameof(Distributor.Id), id.ToString());

        if (!string.IsNullOrWhiteSpace(update.Name))
        {
            foundDistributor.Name = update.Name;
        }

        if (!string.IsNullOrWhiteSpace(update.Address))
        {
            foundDistributor.Address = update.Address;
        }
        
        if (update.Type != null && update.Type.HasValue)
        {
            foundDistributor.Type = update.Type.Value;
        }
    }

    public async Task DeleteAsync(Guid id)
    {
        var foundDistributor = await dbContext.Distributors.FindAsync(id) ??
            throw new ObjectNotFoundException(nameof(Distributor), nameof(Distributor.Id), id.ToString());

        dbContext.Distributors.Remove(foundDistributor);
    }
}