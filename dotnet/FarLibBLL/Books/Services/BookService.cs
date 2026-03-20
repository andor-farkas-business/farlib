using FarLibBLL.Books.Mappers.Interfaces;
using FarLibBLL.Books.Services.Interfaces;
using FarLibCL.Books.Dtos;
using FarLibCL.Books.Entities;
using FarLibCL.Exceptions;
using FarLibDAL.Books.Repositories.Interfaces;

namespace FarLibBLL.Books.Services;

public class BookService(IBookRepository repository, IBookMapper mapper) : IBookService
{
    public async Task AddAsync(AddBookDto add)
    {
        var entity = mapper.MapAddDtoToEntity(add);

        await repository.AddAsync(entity);
        await repository.SaveChangesAsync();
    }

    public async Task<BookDetailsDto> GetByIdAsync(Guid id)
    {
        var entity = await repository.GetByIdAsync(id) ??
            throw new ObjectNotFoundException(nameof(Book), nameof(Book.Id), id.ToString());

        return mapper.MapEntityToDetailsDto(entity);
    }

    public async Task<BookListDto> GetAllAsync(BookFilterDto filter)
    {
        var (totalItems, totalPages, entities) = await repository.GetAllAsync(filter);

        return new BookListDto() {
            Books = [.. entities.Select(mapper.MapEntityToListItemDto)],
            TotalItems = totalItems,
            Page = filter.PageIndex!.Value,
            TotalPages = totalPages,
            };
    }

    public async Task<IList<BookListItemDto>> GetByAuthorAsync(Guid authorId)
    {
        var entities = await repository.GetByAuthorAsync(authorId);

        return [.. entities.Select(mapper.MapEntityToListItemDto)];
    }

    public async Task UpdateAsync(Guid id, UpdateBookDto update)
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