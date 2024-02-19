using System;
using MediatR;
using MusicReviewAPI.Models.DTOs;

namespace MusicReviewAPI.Application.Albums.Queries;

public record GetAllAlbumsQuery(int PageSize = 5, int PageNumber = 1, bool SortReversed = false) : IRequest<ICollection<AlbumDTO>>;

