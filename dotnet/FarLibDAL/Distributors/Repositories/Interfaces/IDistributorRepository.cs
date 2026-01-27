using FarLibCL.Distributors.Dtos;
using FarLibCL.Distributors.Entities;
using FarLibCL.Distributors.Enums;

namespace FarLibDAL.Distributors.Repositories.Interfaces;

public interface IDistributorRepository
{
    Task AddAsync(Distributor distributor);
    Task<Distributor?> GetByIdAsync(Guid id);
    Task<(int, int, IList<Distributor>)> GetAllAsync(DistributorFilterDto filter);
    Task<IList<Distributor>> GetByTypeAsync(DistributorType type);
    Task UpdateAsync(Guid id, UpdateDistributorDto update);
    Task DeleteAsync(Guid id);
    Task SaveChangesAsync();
}