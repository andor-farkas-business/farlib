using FarLibCL.Authors.Dtos;
using FarLibDAL.Authors.Entities;

namespace FarLibDAL.Authors.Repositories.Interfaces;

public interface IAuthorRepository
{
    Task AddAsync(Author author);
    Task<Author?> GetByIdAsync(Guid id);
    Task<IList<Author>> GetAllAsync();
    Task UpdateAsync(Guid id, UpdateAuthorDto update);
    Task DeleteAsync(Guid id);
}