using MediatR;
using MusicReviewAPI.Models.DTOs;

namespace MusicReviewAPI.Application.Albums.Queries;

public record GetAlbumNameWithRatingsQuery(int AlbumId) : IRequest<AlbumWithRatingsDTO>;

