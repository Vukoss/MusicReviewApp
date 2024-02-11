using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicReviewAPI.Application.Musicians.Queries;
using MusicReviewAPI.Data;
using MusicReviewAPI.Models;
using MusicReviewAPI.Models.DTOs;

namespace MusicReviewAPI.Application.Musicians.Handlers;

public class GetMusicianHandler : IRequestHandler<GetMusicianQuery, MusicianDTO>
{
    private readonly DataAccessContext _db;
    private readonly IMapper _mapper;

    public GetMusicianHandler(DataAccessContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    public async Task<MusicianDTO> Handle(GetMusicianQuery request, CancellationToken cancellationToken)
    {
        var musician = await _db.Musicians.FirstOrDefaultAsync(m => m.Id == request.MusicianId);
        var musicianDto = _mapper.Map<MusicianDTO>(musician);
        return musicianDto;
    } 
}