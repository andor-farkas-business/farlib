using FarLibCL.Authors.Dtos;

namespace FarLibBLL.Authors.Services.Interfaces;

public interface IAuthorService
{
    Task AddAsync(AddAuthorDto add);
    Task<AuthorDetailsDto> GetByIdAsync(Guid id);
    Task<IList<AuthorListItemDto>> GetAllAsync();
    Task UpdateAsync(Guid id, UpdateAuthorDto update);
    Task DeleteAsync(Guid id);
}