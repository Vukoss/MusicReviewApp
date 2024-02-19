using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicReviewAPI.Application.Albums.Queries;
using MusicReviewAPI.Data;
using MusicReviewAPI.Models.DTOs;

namespace MusicReviewAPI.Application.Albums.Handlers;

public class GetAllAlbumsHandler : IRequestHandler<GetAllAlbumsQuery, ICollection<AlbumDTO>>
{
    private readonly DataAccessContext _db;
    private readonly IMapper _mapper;

    public GetAllAlbumsHandler(DataAccessContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<ICollection<AlbumDTO>> Handle(GetAllAlbumsQuery request, CancellationToken cancellationToken)
    {
        var albums =  _db.Albums.AsQueryable();

        if (request.SortReversed)
            albums = albums.OrderByDescending(m => m.Id);

        var skipNumber = (request.PageNumber - 1) * request.PageSize;

        albums = albums.Skip(skipNumber).Take(request.PageSize);

        await albums.ToListAsync();

        var albumsDTO = _mapper.Map<ICollection<AlbumDTO>>(albums);

        return albumsDTO;
    }
}

