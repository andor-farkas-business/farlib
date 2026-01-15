using FarLibCL.Distributors.Dtos;
using FarLibCL.Distributors.Enums;
using FarLibDAL.Distributors.Entities;

namespace FarLibDAL.Distributors.Repositories.Interfaces;

public interface IDistributorRepository
{
    Task AddAsync(Distributor distributor);
    Task<Distributor?> GetByIdAsync(Guid id);
    Task<IList<Distributor>> GetAllAsync();
    Task<IList<Distributor>> GetByTypeAsync(DistributorType type);
    Task UpdateAsync(Guid id, UpdateDistributorDto update);
    Task DeleteAsync(Guid id);
}