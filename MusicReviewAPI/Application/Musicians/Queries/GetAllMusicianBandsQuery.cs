using MediatR;
using MusicReviewAPI.Models;

namespace MusicReviewAPI.Application.Musicians.Queries;

public record GetAllMusicianBandsQuery(int MusicianId) : IRequest<ICollection<Band>>;