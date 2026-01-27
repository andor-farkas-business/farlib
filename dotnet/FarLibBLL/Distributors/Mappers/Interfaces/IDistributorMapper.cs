using FarLibCL.Distributors.Dtos;
using FarLibCL.Distributors.Entities;

namespace FarLibBLL.Distributors.Mappers.Interfaces;

public interface IDistributorMapper
{
    Distributor MapAddDtoToEntity(AddDistributorDto dto);
    DistributorDetailsDto MapEntityToDetailsDto(Distributor entity);
    DistributorListItemDto MapEntityToListItemDto(Distributor entity);
}