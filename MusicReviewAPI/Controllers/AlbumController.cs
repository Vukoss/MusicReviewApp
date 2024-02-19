using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusicReviewAPI.Application.Albums.Commands;
using MusicReviewAPI.Application.Albums.Queries;
using MusicReviewAPI.Models;
using MusicReviewAPI.Models.DTOs;

namespace MusicReviewAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlbumController : Controller
{
    private readonly IMediator _mediator;

    public AlbumController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("GetAllAlbums")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Album>))]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetAlbums([FromQuery] int pageSize, [FromQuery] bool sortReversed, [FromQuery] int pageNumber)
    {
        var result = await _mediator.Send(new GetAllAlbumsQuery(pageSize, pageNumber, sortReversed));
        return Ok(result);
    }
    
    [HttpGet("{albumId}")]
    [ProducesResponseType(200, Type = typeof(Album))]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetAlbum(int albumId)
    {
        var result = await _mediator.Send(new GetAlbumQuery(albumId));
        return Ok(result);
    }

    [HttpGet("GetAlbumNameWithRatings")]
    [ProducesResponseType(404)]
    [ProducesResponseType(200)]
    public async Task<IActionResult> GetAlbumNameWithRatings(int albumId)
    {
       var result = await _mediator.Send(new GetAlbumNameWithRatingsQuery(albumId));
       return Ok(result);
    }
        
    [HttpPost("CreateAlbum")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> CreateAlbum([FromBody] AlbumDTO albumCreate, [FromQuery] int bandId)
    {
        if (albumCreate == null)
            return BadRequest(ModelState);

        var allAlbums = await _mediator.Send(new GetAllAlbumsQuery());
        
        var album = allAlbums.FirstOrDefault(a => a.Name.Trim().ToUpper() == albumCreate.Name.ToUpper());
        
        if (album != null)
        {
            ModelState.AddModelError("", "Album already exists");
            return StatusCode(422, ModelState);
        }

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _mediator.Send(new CreateAlbumCommand(albumCreate, bandId));

        return Ok("Successfully created");
    }

    [HttpPut("update/{albumId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> UpdateAlbum(int albumId, [FromBody] AlbumDTO updateAlbum)
    {
        if (updateAlbum == null)
            return BadRequest(ModelState);


        if (albumId != updateAlbum.Id)
            return BadRequest(ModelState);

        if (await _mediator.Send(new AlbumExistsQuery(albumId)) == false)
            return NotFound();
        
        if (!ModelState.IsValid)
            return BadRequest();

        await _mediator.Send(new UpdateAlbumCommand(albumId, updateAlbum));
        
        return NoContent();
    }

    [HttpDelete("remove/{albumId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteAlbum(int albumId)
    {
        var albumExists = await _mediator.Send(new AlbumExistsQuery(albumId));

        if (albumExists == false)
            return NotFound();

        await _mediator.Send(new RemoveAlbumCommand(albumId));

        return NoContent();
    }
}