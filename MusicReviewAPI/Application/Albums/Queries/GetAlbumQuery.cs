using MediatR;
using MusicReviewAPI.Models;

namespace MusicReviewAPI.Application.Albums.Queries;

public record GetAlbumQuery(int AlbumId) : IRequest<Album>;