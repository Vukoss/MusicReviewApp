using MediatR;
using MusicReviewAPI.Models;
using MusicReviewAPI.Models.DTOs;

namespace MusicReviewAPI.Application.Musicians.Queries;

public record GetMusicianQuery(int MusicianId) : IRequest<MusicianDTO>;