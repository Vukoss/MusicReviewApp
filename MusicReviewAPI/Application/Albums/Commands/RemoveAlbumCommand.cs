using MediatR;

namespace MusicReviewAPI.Application.Albums.Commands;

public record RemoveAlbumCommand(int AlbumId) : IRequest;


