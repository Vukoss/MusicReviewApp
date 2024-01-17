using Microsoft.EntityFrameworkCore;
using MusicReviewAPI.Data;
using MusicReviewAPI.Models;
using MusicReviewAPI.Repository.IRepository;

namespace MusicReviewAPI.Repository;

public class BandRepository : IBandRepository
{
    private readonly DataAccessContext _db;

    public BandRepository(DataAccessContext db)
    {
        _db = db;
    }
    
    public async Task<Band> GetBand(int bandId)
    {
        return await _db.Bands.FirstOrDefaultAsync(b => b.Id == bandId);
    }

    public Task<bool> BandExists(int bandId)
    {
        throw new NotImplementedException();
    }

    public Task Save()
    {
        throw new NotImplementedException();
    }
}