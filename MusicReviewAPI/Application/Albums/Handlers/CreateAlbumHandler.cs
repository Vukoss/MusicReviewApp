using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicReviewAPI.Application.Albums.Commands;
using MusicReviewAPI.Data;
using MusicReviewAPI.Models;

namespace MusicReviewAPI.Application.Albums.Handlers;

public class CreateAlbumHandler : IRequestHandler<CreateAlbumCommand>
{
    private readonly DataAccessContext _db;
    private readonly IMapper _mapper;

    public CreateAlbumHandler(DataAccessContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task Handle(CreateAlbumCommand request, CancellationToken cancellationToken)
    {
        var album = _mapper.Map<Album>(request.Album);
        await _db.Albums.AddAsync(album);
        await _db.SaveChangesAsync();
    }
}

