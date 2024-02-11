using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicReviewAPI.Application.Musicians.Queries;
using MusicReviewAPI.Data;
using MusicReviewAPI.Models;

namespace MusicReviewAPI.Application.Musicians.Handlers;

public class GetAllMusicianBandsHandler : IRequestHandler<GetAllMusicianBandsQuery, ICollection<Band>>
{
    private readonly DataAccessContext _db;
    private readonly IMapper _mapper;

    public GetAllMusicianBandsHandler(DataAccessContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<ICollection<Band>> Handle(GetAllMusicianBandsQuery request, CancellationToken cancellationToken)
    {
        var bands = await _db.MusicianBand.Where(m => m.MusicianId == request.MusicianId).Select(m => m.Band).ToListAsync();
        return bands;
    }
}