using MediatR;
using MusicReviewAPI.Models;

namespace MusicReviewAPI.Application.Musicians.Queries;

public record GetAllMusicianAlbumsQuery(int MusicianId) : IRequest<ICollection<Album>>;