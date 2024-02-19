using AutoMapper;
using MediatR;
using MusicReviewAPI.Application.Albums.Commands;
using MusicReviewAPI.Data;
using MusicReviewAPI.Models;

namespace MusicReviewAPI.Application.Albums.Handlers;

public class UpdateAlbumHandler : IRequestHandler<UpdateAlbumCommand>
{
    private readonly DataAccessContext _db;
    private readonly IMapper _mapper;

    public UpdateAlbumHandler(DataAccessContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task Handle(UpdateAlbumCommand request, CancellationToken cancellationToken)
    {
        var album = _mapper.Map<Album>(request.AlbumDTO);
        _db.Albums.Update(album);
        await _db.SaveChangesAsync();
    }
}

