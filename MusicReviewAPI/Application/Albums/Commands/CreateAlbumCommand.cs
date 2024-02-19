using MediatR;
using MusicReviewAPI.Models.DTOs;

namespace MusicReviewAPI.Application.Albums.Commands;

public record CreateAlbumCommand(AlbumDTO Album, int BandId) : IRequest;
	


