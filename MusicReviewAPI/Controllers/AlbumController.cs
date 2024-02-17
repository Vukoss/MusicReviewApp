using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MusicReviewAPI.Models;
using MusicReviewAPI.Models.DTOs;
using MusicReviewAPI.Repository.IRepository;

namespace MusicReviewAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlbumController : Controller
{
    private readonly IAlbumRepository _albumRepository;
    private readonly IMapper _mapper;

    public AlbumController(IAlbumRepository albumRepository, IMapper mapper)
    {
        _albumRepository = albumRepository;
        _mapper = mapper;
    }

    [HttpGet("GetAllAlbums")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Album>))]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetAlbums()
    {
        var albums = await _albumRepository.GetAllAlbums();
        
        if (!albums.Any())
        {
            return StatusCode(404, "Cannot find album");
        }

        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var albumDto = _mapper.Map<List<AlbumDTO>>(albums);
        
        return Ok(albumDto);
    }
    
    [HttpGet("{albumId}")]
    [ProducesResponseType(200, Type = typeof(Album))]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetAlbum(int albumId)
    {
        if (!await _albumRepository.AlbumExists(albumId))
        {
            return NotFound();
        }

        var album = await _albumRepository.GetAlbum(albumId);
        var albumDto = _mapper.Map<AlbumDTO>(album);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        return Ok(albumDto);
    }

    [HttpGet("GetAlbumNameWithRatings")]
    [ProducesResponseType(404)]
    [ProducesResponseType(200)]
    public async Task<IActionResult> GetAlbumWithReviews(int albumId)
    {
        if (!await _albumRepository.AlbumExists(albumId))
            return NotFound();
        
        var album = await _albumRepository.GetAlbum(albumId);
        
        var ratings = new List<int>();
        
        if (album.Reviews != null)
        {
            ratings.AddRange(album.Reviews.Select(a => a.Rating));
        }
        
        var albumWithRatings = new AlbumReviewsDTO()
        {
            AlbumName = album.Name,
            Ratings = ratings
        };
        
       return Ok(albumWithRatings);
    }
        
        
        
    [HttpPost("CreateAlbum")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> CreateAlbum([FromBody] AlbumDTO albumCreate, [FromQuery] int bandId)
    {
        if (albumCreate == null)
            return BadRequest(ModelState);

        var allAlbums = await _albumRepository.GetAllAlbums();
        
        var album = allAlbums.FirstOrDefault(a => a.Name.Trim().ToUpper() == albumCreate.Name.ToUpper());
        
        if (album != null)
        {
            ModelState.AddModelError("", "Album already exists");
            return StatusCode(422, ModelState);
        }

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var newAlbum = _mapper.Map<Album>(albumCreate);
        
        await _albumRepository.CreateAlbum(newAlbum, bandId);

        return Ok("Successfully created");
    }

    [HttpPut("update/{albumId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> UpdateAlbum(int albumId, [FromBody] AlbumDTO updateAlbum)
    {
        if (updateAlbum == null)
        {
            return BadRequest(ModelState);
        }

        if (albumId != updateAlbum.Id)
            return BadRequest(ModelState);

        if (!await _albumRepository.AlbumExists(albumId))
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
            return BadRequest();

        var albumMap = _mapper.Map<Album>(updateAlbum);

        await _albumRepository.UpdateAlbum(albumMap);
        
        return NoContent();
    }

    [HttpDelete("remove/{albumId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteAlbum(int albumId)
    {
        if (!await _albumRepository.AlbumExists(albumId))
            return NotFound();

        var albumToDelete = await _albumRepository.GetAlbum(albumId);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _albumRepository.DeleteAlbum(albumToDelete);

        return NoContent();
    }
}