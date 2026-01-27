using FarLibBLL.Authors.Services.Interfaces;
using FarLibCL.Authors.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FarLibApi.Authors;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class AuthorsController(IAuthorService service) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] AddAuthorDto add)
    {
        await service.AddAsync(add);

        return Created();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AuthorDetailsDto>> GetByIdAsync(Guid id)
    {
        var author = await service.GetByIdAsync(id);

        return Ok(author);
    }

    [HttpGet]
    public async Task<ActionResult<AuthorListDto>> GetAllAsync([FromQuery] AuthorFilterDto filter)
    {
        var authors = await service.GetAllAsync(filter);

        return Ok(authors);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] UpdateAuthorDto update)
    {
        await service.UpdateAsync(id, update);

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        await service.DeleteAsync(id);

        return NoContent();
    }
}