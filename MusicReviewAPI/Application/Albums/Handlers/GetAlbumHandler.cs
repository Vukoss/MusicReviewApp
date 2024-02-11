using MediatR;
using MusicReviewAPI.Application.Albums.Queries;
using MusicReviewAPI.Models;
using MusicReviewAPI.Repository.IRepository;

namespace MusicReviewAPI.Application.Albums.Handlers;

public class GetAlbumHandler : IRequestHandler<GetAlbumQuery, Album>
{
    private readonly IAlbumRepository _albumRepository;

    public GetAlbumHandler(IAlbumRepository albumRepository)
    {
        _albumRepository = albumRepository;
    }
    
    public async Task<Album> Handle(GetAlbumQuery request, CancellationToken cancellationToken)
    {
        return await _albumRepository.GetAlbum(request.AlbumId);
    }
}