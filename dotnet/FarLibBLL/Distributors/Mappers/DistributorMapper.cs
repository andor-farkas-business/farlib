using FarLibBLL.Distributors.Mappers.Interfaces;
using FarLibCL.Authors.Dtos;
using FarLibCL.Books.Dtos;
using FarLibCL.Distributors.Dtos;
using FarLibCL.Distributors.Entities;
using FarLibCL.Stocks.Dtos;

namespace FarLibBLL.Distributors.Mappers;

public class DistributorMapper : IDistributorMapper
{
    public Distributor MapAddDtoToEntity(AddDistributorDto dto)
    {
        return new Distributor
        {
            Name = dto.Name,
            Address = dto.Address,
            Type = dto.Type,
        };
    }

    public DistributorDetailsDto MapEntityToDetailsDto(Distributor entity)
    {
        return new DistributorDetailsDto
        {
            Id = entity.Id,
            Name = entity.Name,
            Address = entity.Address,
            Type = entity.Type
        };
    }

    public DistributorListItemDto MapEntityToListItemDto(Distributor entity)
    {
        return new DistributorListItemDto
        {
            Id = entity.Id,
            Name = entity.Name,
            Type = entity.Type,
        };
    }
}