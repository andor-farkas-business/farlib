using FarLibCL.Authors.Dtos;
using FarLibCL.Authors.Entities;

namespace FarLibBLL.Authors.Mappers.Interfaces;

public interface IAuthorMapper
{
    Author MapAddDtoToEntity(AddAuthorDto dto);
    AuthorDetailsDto MapEntityToDetailsDto(Author entity);
    AuthorListItemDto MapEntityToListItemDto(Author entity);
}