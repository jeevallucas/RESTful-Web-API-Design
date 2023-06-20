using BookStoreApi.Models;
using BookStoreApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class KelassController : ControllerBase
{
    private readonly KelassService _KelassService;

    public KelassController(KelassService KelassService) =>
        _KelassService = KelassService;

    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<List<Kelass>> Get() =>
        await _KelassService.GetAsync();

    [HttpGet("{id:length(24)}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Kelass>> Get(string id)
    {
        var Kelass = await _KelassService.GetAsync(id);

        if (Kelass is null)
        {
            return NotFound();
        }

        return Kelass;
    }

    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Post(Kelass newKelass)
    {
        await _KelassService.CreateAsync(newKelass);

        return CreatedAtAction(nameof(Get), new { id = newKelass.Id }, newKelass);
    }

    [HttpPut("{id:length(24)}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Update(string id, Kelass updatedKelass)
    {
        var Kelass = await _KelassService.GetAsync(id);

        if (Kelass is null)
        {
            return NotFound();
        }

        updatedKelass.Id = Kelass.Id;

        await _KelassService.UpdateAsync(id, updatedKelass);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(string id)
    {
        var Kelass = await _KelassService.GetAsync(id);

        if (Kelass is null)
        {
            return NotFound();
        }

        await _KelassService.RemoveAsync(id);

        return NoContent();
    }
}