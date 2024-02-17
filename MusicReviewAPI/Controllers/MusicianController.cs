using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusicReviewAPI.Application.Musicians.Commands;
using MusicReviewAPI.Application.Musicians.Queries;
using MusicReviewAPI.Models.DTOs;

namespace MusicReviewAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MusicianController : Controller
{
    private readonly IMediator _mediator;

    public MusicianController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("all")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetMusicians([FromQuery] int pageSize, [FromQuery] bool sortReversed, [FromQuery] int pageNumber)
    {
        var result = await _mediator.Send(new GetMusiciansQuery(pageSize, pageNumber, sortReversed));
        return Ok(result);
    }
    
    [HttpGet("{musicianId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetMusician(int musicianId)
    {
        var result = await _mediator.Send(new GetMusicianQuery(musicianId));
        return Ok(result);
    }
    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("best")]
    public async Task<IActionResult> GetBestMusicians()
    {
        var result = await _mediator.Send(new GetBestMusiciansQuery());
        return Ok(result);
    }
    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("bands/{musicianId}")]
    public async Task<IActionResult> GetMusicianBands([FromBody] int musicianId)
    {
        var result = await _mediator.Send(new GetAllMusicianBandsQuery(musicianId));
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateMusician([FromBody] MusicianDTO musicianDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (musicianDto == null)
            return BadRequest();

        await _mediator.Send(new CreateMusicianCommand(musicianDto));
        return Ok();
    }

    //[HttpDelete]
    //[Route("{id:int}")]
    //public async Task<IActionResult> DeleteMusician([FromBody] int musicianId)
    //{
    //    if (!ModelState.IsValid)
    //        return BadRequest(ModelState);
    //}

    //[HttpPut]
    //[Route("{id:int}")]
    //public async Task<IActionResult> UpdateMusician([FromBody] int musicianId)
    //{
    //    if (!ModelState.IsValid)
    //        return BadRequest(ModelState);
    //}
}