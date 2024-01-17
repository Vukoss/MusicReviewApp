using MusicReviewAPI.Models;

namespace MusicReviewAPI.Repository.IRepository;

public interface IAlbumRepository
{
    Task<Album> GetAlbum(int albumId);
    Task<ICollection<Album>> GetAllAlbums();
    Task CreateAlbum(Album album, int bandId); 
    Task<bool> AlbumExists(int albumId);
    Task SaveAsync();
}