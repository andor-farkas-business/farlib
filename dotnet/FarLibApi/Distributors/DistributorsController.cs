using FarLibBLL.Distributors.Services.Interfaces;
using FarLibCL.Distributors.Dtos;
using FarLibCL.Distributors.Enums;
using Microsoft.AspNetCore.Mvc;

namespace FarLibApi.Distributors;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class DistributorsController(IDistributorService service) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] AddDistributorDto add)
    {
        await service.AddAsync(add);

        return Created();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DistributorDetailsDto>> GetByIdAsync(Guid id)
    {
        var distributor = await service.GetByIdAsync(id);

        return Ok(distributor);
    }

    [HttpGet]
    public async Task<ActionResult<DistributorListDto>> GetAllAsync([FromQuery] DistributorFilterDto filter)
    {
        var distributors = await service.GetAllAsync(filter);

        return Ok(distributors);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] UpdateDistributorDto update)
    {
        await service.UpdateAsync(id, update);

        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        await service.DeleteAsync(id);

        return NoContent();
    }
}