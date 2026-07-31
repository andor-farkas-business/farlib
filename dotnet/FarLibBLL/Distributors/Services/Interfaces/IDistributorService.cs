using FarLibCL.Distributors.Dtos;

namespace FarLibBLL.Distributors.Services.Interfaces;

public interface IDistributorService
{
    Task AddAsync(AddDistributorDto add);
    Task<DistributorDetailsDto> GetByIdAsync(Guid id);
    Task<DistributorListDto> GetAllAsync(DistributorFilterDto filter);
    Task UpdateAsync(Guid id, UpdateDistributorDto update);
    Task DeleteAsync(Guid id);
}