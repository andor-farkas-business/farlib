using FarLibBLL.Distributors.Mappers.Interfaces;
using FarLibBLL.Distributors.Services.Interfaces;
using FarLibCL.Distributors.Dtos;
using FarLibCL.Distributors.Entities;
using FarLibCL.Distributors.Enums;
using FarLibCL.Exceptions;
using FarLibDAL.Distributors.Repositories.Interfaces;

namespace FarLibBLL.Distributors.Services;

public class DistributorService(
    IDistributorRepository repository,
    IDistributorMapper mapper) : IDistributorService
{
    public async Task AddAsync(AddDistributorDto add)
    {
        var entity = mapper.MapAddDtoToEntity(add);

        await repository.AddAsync(entity);
        await repository.SaveChangesAsync();
    }

    public async Task<DistributorDetailsDto?> GetByIdAsync(Guid id)
    {
        var entity = await repository.GetByIdAsync(id) ?? 
            throw new ObjectNotFoundException(nameof(Distributor), nameof(Distributor.Id), id.ToString());

        return mapper.MapEntityToDetailsDto(entity);
    }

    public async Task<DistributorListDto> GetAllAsync(DistributorFilterDto filter)
    {
        var (totalItems, totalPages, entities) = await repository.GetAllAsync(filter);

        return new DistributorListDto
        {
            Distributors = [.. entities.Select(mapper.MapEntityToListItemDto)],
            TotalItems = totalItems,
            Page = filter.PageIndex!.Value,
            TotalPages = totalPages
        };
    }

    public async Task<IList<DistributorListItemDto>> GetByTypeAsync(DistributorType type)
    {
        var entities = await repository.GetByTypeAsync(type);

        return [.. entities.Select(mapper.MapEntityToListItemDto)];
    }

    public async Task UpdateAsync(Guid id, UpdateDistributorDto update)
    {
        await repository.UpdateAsync(id, update);
        await repository.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        await repository.DeleteAsync(id);
        await repository.SaveChangesAsync();
    }
}