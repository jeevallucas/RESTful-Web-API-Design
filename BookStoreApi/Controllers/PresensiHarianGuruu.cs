using BookStoreApi.Models;
using BookStoreApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PresensiHarianGuruuController : ControllerBase
{
    private readonly PresensiHarianGuruuService _PresensiHarianGuruuService;

    public PresensiHarianGuruuController(PresensiHarianGuruuService PresensiHarianGuruuService) =>
        _PresensiHarianGuruuService = PresensiHarianGuruuService;

    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<List<PresensiHarianGuruu>> Get() =>
        await _PresensiHarianGuruuService.GetAsync();

    [HttpGet("{id:length(24)}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<PresensiHarianGuruu>> Get(string id)
    {
        var PresensiHarianGuruu = await _PresensiHarianGuruuService.GetAsync(id);

        if (PresensiHarianGuruu is null)
        {
            return NotFound();
        }

        return PresensiHarianGuruu;
    }

    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Post(PresensiHarianGuruu newPresensiHarianGuruu)
    {
        await _PresensiHarianGuruuService.CreateAsync(newPresensiHarianGuruu);

        return CreatedAtAction(nameof(Get), new { id = newPresensiHarianGuruu.Id }, newPresensiHarianGuruu);
    }

    [HttpPut("{id:length(24)}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Update(string id, PresensiHarianGuruu updatedPresensiHarianGuruu)
    {
        var PresensiHarianGuruu = await _PresensiHarianGuruuService.GetAsync(id);

        if (PresensiHarianGuruu is null)
        {
            return NotFound();
        }

        updatedPresensiHarianGuruu.Id = PresensiHarianGuruu.Id;

        await _PresensiHarianGuruuService.UpdateAsync(id, updatedPresensiHarianGuruu);

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
        var PresensiHarianGuruu = await _PresensiHarianGuruuService.GetAsync(id);

        if (PresensiHarianGuruu is null)
        {
            return NotFound();
        }

        await _PresensiHarianGuruuService.RemoveAsync(id);

        return NoContent();
    }
}