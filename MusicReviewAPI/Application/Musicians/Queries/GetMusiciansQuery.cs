using MediatR;

using MusicReviewAPI.Models.DTOs;

namespace MusicReviewAPI.Application.Musicians.Queries;

public record GetMusiciansQuery(int PageSize = 5, int PageNumber = 1, bool SortReversed = false) : IRequest<ICollection<MusicianDTO>>;