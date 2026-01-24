using FarLibCL.Authors.Dtos;
using FarLibCL.Authors.Entities;

namespace FarLibDAL.Authors.Repositories.Interfaces;

public interface IAuthorRepository
{
    Task AddAsync(Author author);
    Task<Author?> GetByIdAsync(Guid id);
    Task<IList<Author>> GetAllAsync();
    Task UpdateAsync(Guid id, UpdateAuthorDto update);
    Task DeleteAsync(Guid id);
    Task SaveChangesAsync();
}