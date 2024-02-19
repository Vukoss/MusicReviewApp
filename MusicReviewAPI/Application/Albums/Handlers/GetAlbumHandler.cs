using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicReviewAPI.Application.Albums.Queries;
using MusicReviewAPI.Data;
using MusicReviewAPI.Models.DTOs;

namespace MusicReviewAPI.Application.Albums.Handlers;

public class GetAlbumHandler : IRequestHandler<GetAlbumQuery, AlbumDTO>
{
    private readonly DataAccessContext _db;
    private readonly IMapper _mapper;

    public GetAlbumHandler(DataAccessContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<AlbumDTO> Handle(GetAlbumQuery request, CancellationToken cancellationToken)
    {
        var result = await _db.Albums.FirstOrDefaultAsync(a => a.Id == request.AlbumId);
        var resultDTO = _mapper.Map<AlbumDTO>(result);
        return resultDTO;
    }
}