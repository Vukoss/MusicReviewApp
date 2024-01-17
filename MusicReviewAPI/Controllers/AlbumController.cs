using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        
        if (albums.Count() == 0)
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
}