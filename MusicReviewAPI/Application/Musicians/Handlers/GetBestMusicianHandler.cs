using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicReviewAPI.Application.Musicians.Queries;
using MusicReviewAPI.Data;
using MusicReviewAPI.Models;

namespace MusicReviewAPI.Application.Musicians.Handlers;

public class GetBestMusiciansHandler : IRequestHandler<GetBestMusiciansQuery, ICollection<Musician>>
{
    private readonly DataAccessContext _db;
    private readonly IMapper _mapper;

    public GetBestMusiciansHandler(DataAccessContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }


    public async Task<ICollection<Musician>> Handle(GetBestMusiciansQuery request, CancellationToken cancellationToken)
    {
        var musiciansWithMoreThanTwoBands = await _db.Musicians
                .Include(m => m.Reviews)
                .Include(m => m.MusicianBands)
                .Where(m => m.MusicianBands.Count() >= 2)
                .ToListAsync();
        
        var bestMusicians = new List<Musician>();
        
        foreach (var musician in musiciansWithMoreThanTwoBands)
        {
            List<int> ratings = new();
            
            foreach (var review in musician.Reviews)
            {
                    ratings.Add(review.Rating);
            }
        
            if (ratings.Average() > 2)
            {
                bestMusicians.Add(musician);
            }
        }
        
        return bestMusicians;
    }
}