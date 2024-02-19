using MediatR;

namespace MusicReviewAPI.Application.Albums.Queries;

public record AlbumExistsQuery(int AlbumId) : IRequest<bool>;


