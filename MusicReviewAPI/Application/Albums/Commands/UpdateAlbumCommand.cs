using MediatR;
using MusicReviewAPI.Models.DTOs;

namespace MusicReviewAPI.Application.Albums.Commands;

public record UpdateAlbumCommand(int AlbumId, AlbumDTO AlbumDTO) : IRequest;

