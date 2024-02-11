using MusicReviewAPI.Models;
using MusicReviewAPI.Models.DTOs;

namespace MusicReviewAPI.Repository.IRepository;

public interface IAlbumRepository
{
    Task<Album> GetAlbum(int albumId);
    Task<ICollection<Album>> GetAllAlbums();
    Task CreateAlbum(Album album, int bandId);
    Task UpdateAlbum(Album album);
    Task DeleteAlbum(Album album);
    Task<bool> AlbumExists(int albumId);
    Task SaveAsync();
}