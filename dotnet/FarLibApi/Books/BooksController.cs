using FarLibBLL.Books.Services.Interfaces;
using FarLibCL.Books.Dtos;
using FarLibCL.Books.Enums;
using Microsoft.AspNetCore.Mvc;

namespace FarLibApi.Books;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class BooksController(IBookService service) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] AddBookDto add)
    {
        await service.AddAsync(add);

        return Created();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BookDetailsDto>> GetByIdAsync(Guid id)
    {
        var book = await service.GetByIdAsync(id);

        return Ok(book);
    }

    [HttpGet]
    public async Task<ActionResult<BookListDto>> GetAllAsync([FromQuery] BookFilterDto filter)
    {
        var books = await service.GetAllAsync(filter);

        return Ok(books);
    }

    [HttpGet("author/{authorId}")]
    public async Task<ActionResult<IList<BookListItemDto>>> GetByAuthorAsync(Guid authorId)
    {
        var books = await service.GetByAuthorAsync(authorId);

        return Ok(books);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] UpdateBookDto update)
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