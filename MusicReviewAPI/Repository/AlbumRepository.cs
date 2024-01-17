using Microsoft.EntityFrameworkCore;
using MusicReviewAPI.Data;
using MusicReviewAPI.Models;
using MusicReviewAPI.Repository.IRepository;

namespace MusicReviewAPI.Repository;

public class AlbumRepository : IAlbumRepository
{
    private readonly DataAccessContext _db;

    public AlbumRepository(DataAccessContext db)
    {
        _db = db;
    }
    
    public async Task<Album> GetAlbum(int albumId)
    {
        var output = await _db.Albums.FirstOrDefaultAsync(a => a.Id == albumId);
        return output;
    }

    public async Task<ICollection<Album>> GetAllAlbums()
    {
        return await _db.Albums.ToListAsync();
    }

    public async Task CreateAlbum(Album album, int bandId)
    { 
        var band = await _db.Bands.FirstOrDefaultAsync(b => b.Id == bandId);
        album.Band = band;
       await _db.Albums.AddAsync(album);
       await SaveAsync();
    }

    public async Task<bool> AlbumExists(int albumId)
    {
        return await _db.Albums.AnyAsync(a => a.Id == albumId);
    }

    public async Task SaveAsync()
    {
        await _db.SaveChangesAsync();
    }
}