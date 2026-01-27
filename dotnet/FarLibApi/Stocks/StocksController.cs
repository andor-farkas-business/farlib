using FarLibBLL.Stocks.Services.Interfaces;
using FarLibCL.Stocks.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FarLibApi.Stocks;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class StocksController(IStockService service) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] AddStockDto add)
    {
        await service.AddAsync(add);

        return Created();
    }

    [HttpGet("details")]
    public async Task<ActionResult<StockDetailsDto>> GetByIdAsync(Guid bookId, Guid distributorId)
    {
        var stock = await service.GetByIdAsync(bookId, distributorId);

        return Ok(stock);
    }

    [HttpGet]
    public async Task<ActionResult<StockListDto>> GetAllAsync([FromQuery] StockFilterDto filter)
    {
        var stocks = await service.GetAllAsync(filter);

        return Ok(stocks);
    }

    [HttpGet("book/{bookId}")]
    public async Task<ActionResult<BookStockListDto>> GetByBookIdAsync(Guid bookId, [FromQuery] StockFilterDto filter)
    {
        var stocks = await service.GetByBookIdAsync(bookId, filter);

        return Ok(stocks);
    }

    [HttpGet("distributor/{distributorId}")]
    public async Task<ActionResult<DistributorStockListDto>> GetByDistributorIdAsync(Guid distributorId, [FromQuery] StockFilterDto filter)
    {
        var stocks = await service.GetByDistributorIdAsync(distributorId, filter);

        return Ok(stocks);
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateAsync(Guid bookId, Guid distributorId, [FromBody] int update)
    {
        await service.UpdateAsync(bookId, distributorId, update);

        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(Guid bookId, Guid distributorId)
    {
        await service.DeleteAsync(bookId, distributorId);

        return NoContent();
    }
}