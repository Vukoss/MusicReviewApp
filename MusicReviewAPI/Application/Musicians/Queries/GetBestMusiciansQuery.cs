using MediatR;
using MusicReviewAPI.Models;

namespace MusicReviewAPI.Application.Musicians.Queries;

public record GetBestMusiciansQuery() : IRequest<ICollection<Musician>>;