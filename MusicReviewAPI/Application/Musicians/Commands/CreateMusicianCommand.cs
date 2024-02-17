
using MediatR;
using MusicReviewAPI.Models;
using MusicReviewAPI.Models.DTOs;

namespace MusicReviewAPI.Application.Musicians.Commands;

public record CreateMusicianCommand(MusicianDTO Musician) : IRequest;