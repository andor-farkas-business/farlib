using FarLibBLL.Authors.Mappers.Interfaces;
using FarLibBLL.Authors.Services.Interfaces;
using FarLibCL.Authors.Dtos;
using FarLibCL.Authors.Entities;
using FarLibCL.Exceptions;
using FarLibDAL.Authors.Repositories.Interfaces;

namespace FarLibBLL.Authors.Services;

public class AuthorService(
    IAuthorRepository repository,
    IAuthorMapper mapper) : IAuthorService
{
    public async Task AddAsync(AddAuthorDto add)
    {
        var author = mapper.MapAddDtoToEntity(add);

        await repository.AddAsync(author);
        await repository.SaveChangesAsync();
    }

    public async Task<AuthorDetailsDto> GetByIdAsync(Guid id)
    {
        var entity = await repository.GetByIdAsync(id) ??
            throw new ObjectNotFoundException(nameof(Author), nameof(Author.Id), id.ToString());

        return mapper.MapEntityToDetailsDto(entity);
    }

    public async Task<IList<AuthorListItemDto>> GetAllAsync()
    {
        var entities = await repository.GetAllAsync();

        return [.. entities.Select(mapper.MapEntityToListItemDto)];
    }

    public async Task UpdateAsync(Guid id, UpdateAuthorDto update)
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