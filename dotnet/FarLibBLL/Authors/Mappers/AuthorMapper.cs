using FarLibBLL.Authors.Mappers.Interfaces;
using FarLibCL.Authors.Dtos;
using FarLibCL.Authors.Entities;
using FarLibCL.Books.Dtos;

namespace FarLibBLL.Authors.Mappers;

public class AuthorMapper : IAuthorMapper
{
    public Author MapAddDtoToEntity(AddAuthorDto dto)
    {
        return new Author
        {
            Id = Guid.Empty,
            Name = dto.Name,
            Description = dto.Description
        };
    }

    public AuthorDetailsDto MapEntityToDetailsDto(Author entity)
    {
        return new AuthorDetailsDto
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description ?? string.Empty,
            Books = [.. entity.Books.Select(b => new AuthorBookListItemDto
            {
                Id = b.Id,
                Title = b.Title,
                Description = b.Description
            })]
        };
    }

    public AuthorListItemDto MapEntityToListItemDto(Author entity)
    {
        return new AuthorListItemDto
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description ?? string.Empty
        };
    }
}