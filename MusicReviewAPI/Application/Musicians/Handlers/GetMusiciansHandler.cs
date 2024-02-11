using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicReviewAPI.Application.Musicians.Queries;
using MusicReviewAPI.Data;
using MusicReviewAPI.Models.DTOs;

namespace MusicReviewAPI.Application.Musicians.Handlers;

public class GetMusiciansHandler : IRequestHandler<GetMusiciansQuery, ICollection<MusicianDTO>>
{
    private readonly DataAccessContext _db;
    private readonly IMapper _mapper;

    public GetMusiciansHandler(DataAccessContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    public async Task<ICollection<MusicianDTO>> Handle(GetMusiciansQuery request, CancellationToken cancellationToken)
    {
        var musicians = _db.Musicians.AsQueryable();

        if (request.SortReversed)
            musicians = musicians.OrderByDescending(m => m.Id);

        var skipNumber = (request.PageNumber - 1) * request.PageSize;

        musicians = musicians.Skip(skipNumber).Take(request.PageSize);

        await musicians.ToListAsync();
        
        var musiciansDTO = _mapper.Map<ICollection<MusicianDTO>>(musicians);
        
        return musiciansDTO;
    } 
}