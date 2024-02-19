using MediatR;
using MusicReviewAPI.Models.DTOs;

namespace MusicReviewAPI.Application.Albums.Queries;

public record GetAlbumQuery(int AlbumId) : IRequest<AlbumDTO>;