using BookStoreApi.Models;
using BookStoreApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;

namespace BookStoreApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class BooksController : ControllerBase
{
    private readonly BooksService _booksService;

    public BooksController(BooksService booksService) =>
        _booksService = booksService;

    /// <summary>
    /// Shows all BookStoreItem
    /// </summary>
    /// <returns>Shown every BookStoreItem</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /BookStore
    ///     {
    ///        "Id": "string",
    ///        "BookName": "Book Item #1",
    ///        "Price": 0,
    ///        "Category": "Category #1",
    ///        "Author": "Author #1"
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null or invalid</response>
    /// <response code="401">If the user is not authorized to perform the operation</response>
    /// <response code="404">If the requested item is not found</response>
    /// <response code="500">If there is a server error</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<List<Book>> Get() =>
        await _booksService.GetAsync();

    /// <summary>
    /// Shows a spesific BookStoreItem
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Shown one BookStoreItem</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /BookStore
    ///     {
    ///        "Id": "string"
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null or invalid</response>
    /// <response code="401">If the user is not authorized to perform the operation</response>
    /// <response code="404">If the requested item is not found</response>
    /// <response code="500">If there is a server error</response>
    [HttpGet("{id:length(24)}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Book>> Get(string id)
    {
        var book = await _booksService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        return book;
    }

    /// <summary>
    /// Creates a BookStoreItem
    /// </summary>
    /// <param name="newBook"></param>
    /// <returns>A newly created BookStoreItem</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /BookStore
    ///     {
    ///        "Id": "string",
    ///        "BookName": "Book Item #1",
    ///        "Price": 0,
    ///        "Category": "Category #1",
    ///        "Author": "Author #1"
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null or invalid</response>
    /// <response code="401">If the user is not authorized to perform the operation</response>
    /// <response code="404">If the requested item is not found</response>
    /// <response code="500">If there is a server error</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Post(Book newBook)
    {
        try
        {
            if (newBook == null)
            {
                return BadRequest();
            }

            await _booksService.CreateAsync(newBook);

            return CreatedAtAction(nameof(Get), new { id = newBook.Id }, newBook);
        }

        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
            "Error retrieving data from the database");
        }
    }

    /// <summary>
    /// Updates a spesific BookStoreItem
    /// </summary>
    /// <param name="id"></param>
    /// <param name="updatedBook"></param>
    /// <returns>One updated BookStoreItem</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     PUT /BookStore
    ///     {
    ///        "Id": "string",
    ///        "BookName": "Book Item #1",
    ///        "Price": 0,
    ///        "Category": "Category #1",
    ///        "Author": "Author #1"
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null or invalid</response>
    /// <response code="401">If the user is not authorized to perform the operation</response>
    /// <response code="404">If the requested item is not found</response>
    /// <response code="500">If there is a server error</response>
    [HttpPut("{id:length(24)}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Update(string id, Book updatedBook)
    {
        var book = await _booksService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        updatedBook.Id = book.Id;

        await _booksService.UpdateAsync(id, updatedBook);

        return NoContent();
    }

    /// <summary>
    /// Deletes a specific BookStoreItem
    /// </summary>
    /// <param name="id"></param>
    /// <returns>One deleted BookStorItem</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     DELETE /BookStore
    ///     {
    ///        "Id": "string"
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null or invalid</response>
    /// <response code="401">If the user is not authorized to perform the operation</response>
    /// <response code="404">If the requested item is not found</response>
    /// <response code="500">If there is a server error</response>
    [HttpDelete("{id:length(24)}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(string id)
    {
        var book = await _booksService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        await _booksService.RemoveAsync(id);

        return NoContent();
    }
}